using InventarySystem.Api.Modules.Inventory.Domain.Entities;
using InventarySystem.Api.Modules.Inventory.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Inventory.Infrastructure.Repositories;

public class CompanySkuRepository(AppDbContext db) : ICompanySkuRepository
{
    public async Task<IEnumerable<CompanySkuEntity>> GetAllByProductAsync(int companyProductId)
    {
        var models = await db.CompanySkus
            .Where(s => s.CompanyProductId == companyProductId && s.IsActive == true)
            .ToListAsync();
        return models.Select(Map);
    }

    public async Task<CompanySkuEntity?> GetByIdAsync(int id)
    {
        var model = await db.CompanySkus
            .FirstOrDefaultAsync(s => s.Id == id && s.IsActive == true);
        return model is null ? null : Map(model);
    }

    public async Task<CompanySkuEntity> CreateAsync(CompanySkuEntity entity)
    {
        var model = new CompanySku
        {
            CompanyProductId = entity.CompanyProductId,
            InternalSku = entity.InternalSku,
            RetailPrice = entity.RetailPrice,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
        db.CompanySkus.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    public async Task DeactivateAsync(int id)
    {
        var model = await db.CompanySkus.FindAsync(id);
        if (model is null) throw new KeyNotFoundException($"CompanySku {id} not found");
        model.IsActive = false;
        await db.SaveChangesAsync();
    }

    private static CompanySkuEntity Map(CompanySku m) =>
        new CompanySkuEntity().Init(m.Id, m.CompanyProductId, m.InternalSku!, m.RetailPrice ?? 0, m.IsActive ?? true, m.CreatedAt ?? DateTime.Now);
}