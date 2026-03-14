using InventarySystem.Api.Modules.Inventory.Domain.Entities;

namespace InventarySystem.Api.Modules.Inventory.Domain.Interfaces;

public interface IKardexRepository
{
    Task<IEnumerable<KardexEntity>> GetBySkuAndWarehouseAsync(int skuId, int warehouseId);
    Task<KardexEntity> CreateAsync(KardexEntity entity);
}