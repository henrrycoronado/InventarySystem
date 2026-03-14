using InventarySystem.Api.Modules.Inventory.Application.DTOs;

namespace InventarySystem.Api.Modules.Inventory.Application.Interfaces;

public interface IKardexService
{
    Task<IEnumerable<KardexDto>> GetBySkuAndWarehouseAsync(int skuId, int warehouseId);
}