using InventarySystem.Api.Modules.Inventory.Application.Interfaces;
using InventarySystem.Api.Modules.Inventory.Application.DTOs;
using InventarySystem.Api.src.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InventarySystem.Api.Modules.Inventory.Presentation.Controllers;

[ApiController]
[Route("api/warehouses/{warehouseId:int}/kardex")]
public class KardexController(IKardexService service) : ControllerBase
{
    [HttpGet("sku/{skuId:int}")]
    public async Task<IActionResult> GetBySkuAndWarehouse(int warehouseId, int skuId)
    {
        var result = await service.GetBySkuAndWarehouseAsync(skuId, warehouseId);
        return Ok(ApiResponse<IEnumerable<KardexDto>>.Ok(result));
    }
}