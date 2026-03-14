using InventarySystem.Api.src.Core.Domain.Entities;
using InventarySystem.Api.src.Core.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.src.Core.Infrastructure.Repositories;

public class WarehouseRepository(AppDbContext db) : IWarehouseRepository
{
    public async Task<IEnumerable<WarehouseEntity>> GetAllByCompanyAsync(int companyId)
    {
        var models = await db.Warehouses
            .Where(w => w.CompanyId == companyId && w.IsActive == true)
            .ToListAsync();

        return models.Select(w => new WarehouseEntity().Init(w.Id, w.CompanyId, w.Name!, w.IsActive ?? true, w.CreatedAt ?? DateTime.UtcNow));
    }

    public async Task<WarehouseEntity?> GetByIdAsync(int id, int companyId)
    {
        var model = await db.Warehouses
            .FirstOrDefaultAsync(w => w.Id == id && w.CompanyId == companyId && w.IsActive == true);

        return model is null ? null : new WarehouseEntity().Init(model.Id, model.CompanyId, model.Name!, model.IsActive ?? true, model.CreatedAt ?? DateTime.UtcNow);
    }

    public async Task<WarehouseEntity> CreateAsync(WarehouseEntity entity)
    {
        var model = new Warehouse
        {
            CompanyId = entity.CompanyId,
            Name = entity.Name,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };

        db.Warehouses.Add(model);
        await db.SaveChangesAsync();

        return new WarehouseEntity().Init(model.Id, model.CompanyId, model.Name!, model.IsActive ?? true, model.CreatedAt ?? DateTime.UtcNow);
    }

    public async Task DeactivateAsync(int id)
    {
        var model = await db.Warehouses.FindAsync(id);
        if (model is null) throw new KeyNotFoundException($"Warehouse {id} not found");
        model.IsActive = false;
        await db.SaveChangesAsync();
    }
}