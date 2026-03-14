using InventarySystem.Api.Modules.Inventory.Domain.Entities;
using InventarySystem.Api.Modules.Inventory.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Inventory.Infrastructure.Repositories;

public class MovementDetailRepository(AppDbContext db) : IMovementDetailRepository
{
    public async Task<IEnumerable<MovementDetailEntity>> GetAllByMovementAsync(int movementId)
    {
        var models = await db.MovementDetails
            .Where(d => d.MovementId == movementId && d.IsActive == true)
            .ToListAsync();
        return models.Select(Map);
    }

    public async Task<MovementDetailEntity> CreateAsync(MovementDetailEntity entity)
    {
        var model = new MovementDetail
        {
            MovementId = entity.MovementId,
            SkuId = entity.SkuId,
            BatchId = entity.BatchId,
            Quantity = entity.Quantity,
            UnitCost = entity.UnitCost,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
        db.MovementDetails.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    private static MovementDetailEntity Map(MovementDetail m) =>
        new MovementDetailEntity().Init(m.Id, m.MovementId, m.SkuId, m.BatchId, m.Quantity, m.UnitCost, m.IsActive ?? true, m.CreatedAt ?? DateTime.Now);
}