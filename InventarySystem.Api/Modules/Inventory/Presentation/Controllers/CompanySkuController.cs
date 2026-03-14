using InventarySystem.Api.Modules.Inventory.Application.DTOs;
using InventarySystem.Api.Modules.Inventory.Application.Interfaces;
using InventarySystem.Api.src.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InventarySystem.Api.Modules.Inventory.Presentation.Controllers;

[ApiController]
[Route("api/products/{companyProductId:int}/skus")]
public class CompanySkuController(ICompanySkuService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(int companyProductId)
    {
        var result = await service.GetAllByProductAsync(companyProductId);
        return Ok(ApiResponse<IEnumerable<CompanySkuDto>>.Ok(result));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int companyProductId, int id)
    {
        var result = await service.GetByIdAsync(id);
        if (result is null) return NotFound(ApiResponse<object>.Fail($"SKU {id} not found"));
        return Ok(ApiResponse<CompanySkuDto>.Ok(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create(int companyProductId, [FromBody] CompanySkuCreateDto dto)
    {
        dto.CompanyProductId = companyProductId;
        var result = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { companyProductId, id = result.Id }, ApiResponse<CompanySkuDto>.Ok(result));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Deactivate(int companyProductId, int id)
    {
        try
        {
            await service.DeactivateAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound(ApiResponse<object>.Fail($"SKU {id} not found"));
        }
    }
}