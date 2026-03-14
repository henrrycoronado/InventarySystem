using InventarySystem.Api.Modules.Inventory.Domain.Entities;

namespace InventarySystem.Api.Modules.Inventory.Domain.Interfaces;

public interface IMovementRepository
{
    Task<IEnumerable<MovementEntity>> GetAllByCompanyAsync(int companyId);
    Task<MovementEntity?> GetByIdAsync(int id);
    Task<MovementEntity> CreateAsync(MovementEntity entity);
    Task DeactivateAsync(int id);
}