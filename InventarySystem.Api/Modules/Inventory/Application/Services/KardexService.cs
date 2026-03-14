using InventarySystem.Api.Modules.Inventory.Application.DTOs;
using InventarySystem.Api.Modules.Inventory.Application.Interfaces;
using InventarySystem.Api.Modules.Inventory.Domain.Interfaces;

namespace InventarySystem.Api.Modules.Inventory.Application.Services;

public class KardexService(IKardexRepository repository) : IKardexService
{
    public async Task<IEnumerable<KardexDto>> GetBySkuAndWarehouseAsync(int skuId, int warehouseId)
    {
        var items = await repository.GetBySkuAndWarehouseAsync(skuId, warehouseId);
        return items.Select(e => new KardexDto
        {
            Id = e.Id, CompanyId = e.CompanyId, WarehouseId = e.WarehouseId,
            SkuId = e.SkuId, BatchId = e.BatchId, TypeId = e.TypeId,
            Quantity = e.Quantity, BalanceAfter = e.BalanceAfter, CreatedAt = e.CreatedAt
        });
    }
}