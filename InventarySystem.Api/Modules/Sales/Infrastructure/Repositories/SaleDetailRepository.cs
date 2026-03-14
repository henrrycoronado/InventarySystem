using InventarySystem.Api.Modules.Sales.Domain.Entities;
using InventarySystem.Api.Modules.Sales.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Sales.Infrastructure.Repositories;

public class SaleDetailRepository(AppDbContext db) : ISaleDetailRepository
{
    public async Task<IEnumerable<SaleDetailEntity>> GetAllBySaleAsync(int saleId)
    {
        var models = await db.SaleDetails
            .Where(d => d.SaleId == saleId && d.IsActive == true)
            .ToListAsync();
        return models.Select(Map);
    }

    public async Task<SaleDetailEntity> CreateAsync(SaleDetailEntity entity)
    {
        var model = new SaleDetail
        {
            SaleId = entity.SaleId,
            SkuId = entity.SkuId,
            BatchId = entity.BatchId,
            Quantity = entity.Quantity,
            UnitPrice = entity.UnitPrice,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
        db.SaleDetails.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    private static SaleDetailEntity Map(SaleDetail m) =>
        new SaleDetailEntity().Init(m.Id, m.SaleId, m.SkuId, m.BatchId, m.Quantity, m.UnitPrice, m.IsActive ?? true, m.CreatedAt ?? DateTime.Now);
}