using InventarySystem.Api.src.Core.Domain.Entities;
using InventarySystem.Api.src.Core.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.src.Core.Infrastructure.Repositories;

public class GlobalCategoryRepository(AppDbContext db) : IGlobalCategoryRepository
{
    public async Task<IEnumerable<GlobalCategoryEntity>> GetAllActiveAsync()
    {
        var models = await db.GlobalCategories
            .Where(c => c.IsActive == true)
            .ToListAsync();

        return models.Select(c => new GlobalCategoryEntity().Init(c.Id, c.Name!, c.IsActive ?? true, c.CreatedAt ?? DateTime.UtcNow));
    }

    public async Task<GlobalCategoryEntity?> GetByIdAsync(int id)
    {
        var model = await db.GlobalCategories
            .FirstOrDefaultAsync(c => c.Id == id && c.IsActive == true);

        return model is null ? null : new GlobalCategoryEntity().Init(model.Id, model.Name!, model.IsActive ?? true, model.CreatedAt ?? DateTime.UtcNow);
    }

    public async Task<GlobalCategoryEntity> CreateAsync(GlobalCategoryEntity entity)
    {
        var model = new GlobalCategory { Name = entity.Name, IsActive = entity.IsActive, CreatedAt = entity.CreatedAt };
        db.GlobalCategories.Add(model);
        await db.SaveChangesAsync();
        return new GlobalCategoryEntity().Init(model.Id, model.Name!, model.IsActive ?? true, model.CreatedAt ?? DateTime.UtcNow);
    }

    public async Task DeactivateAsync(int id)
    {
        var model = await db.GlobalCategories.FindAsync(id);
        if (model is null) throw new KeyNotFoundException($"GlobalCategory {id} not found");
        model.IsActive = false;
        await db.SaveChangesAsync();
    }
}