using InventarySystem.Api.Modules.Inventory.Domain.Entities;

namespace InventarySystem.Api.Modules.Inventory.Domain.Interfaces;

public interface IStockRepository
{
    Task<IEnumerable<StockEntity>> GetAllByWarehouseAsync(int warehouseId);
    Task<StockEntity?> GetBySkuAndWarehouseAsync(int skuId, int warehouseId, int? batchId);
    Task<StockEntity> CreateAsync(StockEntity entity);
    Task UpdateAsync(StockEntity entity);
}