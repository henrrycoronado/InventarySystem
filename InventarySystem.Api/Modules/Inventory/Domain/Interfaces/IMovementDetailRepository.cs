using InventarySystem.Api.Modules.Inventory.Domain.Entities;

namespace InventarySystem.Api.Modules.Inventory.Domain.Interfaces;

public interface IMovementDetailRepository
{
    Task<IEnumerable<MovementDetailEntity>> GetAllByMovementAsync(int movementId);
    Task<MovementDetailEntity> CreateAsync(MovementDetailEntity entity);
}