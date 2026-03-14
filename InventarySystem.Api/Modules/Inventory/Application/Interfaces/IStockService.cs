using InventarySystem.Api.Modules.Inventory.Application.DTOs;

namespace InventarySystem.Api.Modules.Inventory.Application.Interfaces;

public interface IStockService
{
    Task<IEnumerable<StockDto>> GetAllByWarehouseAsync(int warehouseId);
    Task<StockDto?> GetAvailableAsync(int skuId, int warehouseId, int? batchId);
    Task<StockDto> CreateAsync(StockCreateDto dto);
}