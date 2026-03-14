using InventarySystem.Api.Modules.Sales.Domain.Entities;
using InventarySystem.Api.Modules.Sales.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Sales.Infrastructure.Repositories;

public class SellerRepository(AppDbContext db) : ISellerRepository
{
    public async Task<IEnumerable<SellerEntity>> GetAllByCompanyAsync(int companyId)
    {
        var models = await db.Sellers
            .Where(s => s.CompanyId == companyId && s.IsActive == true)
            .ToListAsync();
        return models.Select(Map);
    }

    public async Task<SellerEntity?> GetByIdAsync(int id, int companyId)
    {
        var model = await db.Sellers
            .FirstOrDefaultAsync(s => s.Id == id && s.CompanyId == companyId && s.IsActive == true);
        return model is null ? null : Map(model);
    }

    public async Task<SellerEntity> CreateAsync(SellerEntity entity)
    {
        var model = new Seller
        {
            CompanyId = entity.CompanyId,
            Name = entity.Name,
            Phone = entity.Phone,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
        db.Sellers.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    public async Task DeactivateAsync(int id)
    {
        var model = await db.Sellers.FindAsync(id);
        if (model is null) throw new KeyNotFoundException($"Seller {id} not found");
        model.IsActive = false;
        await db.SaveChangesAsync();
    }

    private static SellerEntity Map(Seller m) =>
        new SellerEntity().Init(m.Id, m.CompanyId, m.Name!, m.Phone, m.IsActive ?? true, m.CreatedAt ?? DateTime.Now);
}