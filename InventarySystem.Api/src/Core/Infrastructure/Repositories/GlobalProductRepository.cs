using InventarySystem.Api.src.Core.Domain.Entities;
using InventarySystem.Api.src.Core.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.src.Core.Infrastructure.Repositories;

public class GlobalProductRepository(AppDbContext db) : IGlobalProductRepository
{
    public async Task<IEnumerable<GlobalProductEntity>> GetAllActiveAsync()
    {
        var models = await db.GlobalProducts.Where(p => p.IsActive == true).ToListAsync();
        return models.Select(Map);
    }

    public async Task<GlobalProductEntity?> GetByIdAsync(int id)
    {
        var model = await db.GlobalProducts.FirstOrDefaultAsync(p => p.Id == id && p.IsActive == true);
        return model is null ? null : Map(model);
    }

    public async Task<GlobalProductEntity?> GetByUpcAsync(string upc)
    {
        var model = await db.GlobalProducts.FirstOrDefaultAsync(p => p.UpcBarcode == upc && p.IsActive == true);
        return model is null ? null : Map(model);
    }

    public async Task<GlobalProductEntity> CreateAsync(GlobalProductEntity entity)
    {
        var model = new GlobalProduct
        {
            CategoryId = entity.CategoryId,
            Name = entity.Name,
            Brand = entity.Brand,
            UpcBarcode = entity.UpcBarcode,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
        db.GlobalProducts.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    public async Task DeactivateAsync(int id)
    {
        var model = await db.GlobalProducts.FindAsync(id);
        if (model is null) throw new KeyNotFoundException($"GlobalProduct {id} not found");
        model.IsActive = false;
        await db.SaveChangesAsync();
    }

    private static GlobalProductEntity Map(GlobalProduct m) =>
        new GlobalProductEntity().Init(m.Id, m.CategoryId, m.Name!, m.Brand, m.UpcBarcode, m.IsActive ?? true, m.CreatedAt ?? DateTime.UtcNow);
}