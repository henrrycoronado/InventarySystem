using InventarySystem.Api.Modules.Sales.Domain.Entities;
using InventarySystem.Api.Modules.Sales.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Sales.Infrastructure.Repositories;

public class ReceiptRepository(AppDbContext db) : IReceiptRepository
{
    public async Task<ReceiptEntity?> GetBySaleAsync(int saleId)
    {
        var model = await db.Receipts
            .FirstOrDefaultAsync(r => r.SaleId == saleId && r.IsActive == true);
        return model is null ? null : Map(model);
    }

    public async Task<ReceiptEntity> CreateAsync(ReceiptEntity entity)
    {
        var model = new Receipt
        {
            SaleId = entity.SaleId,
            TotalAmount = entity.TotalAmount,
            IssuedAt = entity.IssuedAt,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
        db.Receipts.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    private static ReceiptEntity Map(Receipt m) =>
        new ReceiptEntity().Init(m.Id, m.SaleId, m.TotalAmount, m.IssuedAt ?? DateTime.Now, m.IsActive ?? true, m.CreatedAt ?? DateTime.Now);
}