using InventarySystem.Api.Modules.Inventory.Application.DTOs;
using InventarySystem.Api.Modules.Inventory.Application.Interfaces;
using InventarySystem.Api.src.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InventarySystem.Api.Modules.Inventory.Presentation.Controllers;

[ApiController]
[Route("api/warehouses/{warehouseId:int}/stocks")]
public class StockController(IStockService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(int warehouseId)
    {
        var result = await service.GetAllByWarehouseAsync(warehouseId);
        return Ok(ApiResponse<IEnumerable<StockDto>>.Ok(result));
    }

    [HttpGet("sku/{skuId:int}")]
    public async Task<IActionResult> GetAvailable(int warehouseId, int skuId, [FromQuery] int? batchId)
    {
        var result = await service.GetAvailableAsync(skuId, warehouseId, batchId);
        if (result is null) return NotFound(ApiResponse<object>.Fail($"Stock for SKU {skuId} not found"));
        return Ok(ApiResponse<StockDto>.Ok(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create(int warehouseId, [FromBody] StockCreateDto dto)
    {
        dto.WarehouseId = warehouseId;
        var result = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAvailable), new { warehouseId, skuId = result.SkuId }, ApiResponse<StockDto>.Ok(result));
    }
}