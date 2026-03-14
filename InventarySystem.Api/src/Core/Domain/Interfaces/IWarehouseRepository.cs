using InventarySystem.Api.src.Core.Domain.Entities;

namespace InventarySystem.Api.src.Core.Domain.Interfaces;

public interface IWarehouseRepository
{
    Task<IEnumerable<WarehouseEntity>> GetAllByCompanyAsync(int companyId);
    Task<WarehouseEntity?> GetByIdAsync(int id, int companyId);
    Task<WarehouseEntity> CreateAsync(WarehouseEntity warehouse);
    Task DeactivateAsync(int id);
}