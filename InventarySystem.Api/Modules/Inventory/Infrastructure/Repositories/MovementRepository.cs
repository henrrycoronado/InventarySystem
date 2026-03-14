using InventarySystem.Api.Modules.Inventory.Domain.Entities;
using InventarySystem.Api.Modules.Inventory.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Inventory.Infrastructure.Repositories;

public class MovementRepository(AppDbContext db) : IMovementRepository
{
    public async Task<IEnumerable<MovementEntity>> GetAllByCompanyAsync(int companyId)
    {
        var models = await db.Movements
            .Where(m => m.CompanyId == companyId && m.IsActive == true)
            .ToListAsync();
        return models.Select(Map);
    }

    public async Task<MovementEntity?> GetByIdAsync(int id)
    {
        var model = await db.Movements
            .FirstOrDefaultAsync(m => m.Id == id && m.IsActive == true);
        return model is null ? null : Map(model);
    }

    public async Task<MovementEntity> CreateAsync(MovementEntity entity)
    {
        var model = new Movement
        {
            CompanyId = entity.CompanyId,
            WarehouseId = entity.WarehouseId,
            TargetWarehouseId = entity.TargetWarehouseId,
            StatusId = entity.StatusId,
            TypeId = entity.TypeId,
            Notes = entity.Notes,
            MovementDate = entity.MovementDate,
            IsActive = entity.IsActive,
            CreatedAt = DateTime.Now
        };
        db.Movements.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    public async Task DeactivateAsync(int id)
    {
        var model = await db.Movements.FindAsync(id);
        if (model is null) throw new KeyNotFoundException($"Movement {id} not found");
        model.IsActive = false;
        await db.SaveChangesAsync();
    }

    private static MovementEntity Map(Movement m) =>
        new MovementEntity().Init(m.Id, m.CompanyId, m.WarehouseId, m.TargetWarehouseId, m.StatusId, m.TypeId, m.MovementDate ?? DateTime.Now, m.Notes, m.IsActive ?? true);
}