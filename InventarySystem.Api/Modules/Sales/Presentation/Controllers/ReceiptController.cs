using InventarySystem.Api.Modules.Sales.Application.Interfaces;
using InventarySystem.Api.Modules.Sales.Application.DTOs;
using InventarySystem.Api.src.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InventarySystem.Api.Modules.Sales.Presentation.Controllers;

[ApiController]
[Route("api/sales/{saleId:int}/receipt")]
public class ReceiptController(IReceiptService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBySale(int saleId)
    {
        var result = await service.GetBySaleAsync(saleId);
        if (result is null) return NotFound(ApiResponse<object>.Fail($"Receipt for sale {saleId} not found"));
        return Ok(ApiResponse<ReceiptDto>.Ok(result));
    }

    [HttpPost]
    public async Task<IActionResult> Generate(int saleId)
    {
        try
        {
            var result = await service.GenerateAsync(saleId);
            return CreatedAtAction(nameof(GetBySale), new { saleId }, ApiResponse<ReceiptDto>.Ok(result));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ApiResponse<object>.Fail(ex.Message));
        }
    }
}