using InventarySystem.Api.Modules.Inventory.Application.DTOs;
using InventarySystem.Api.Modules.Inventory.Application.Interfaces;
using InventarySystem.Api.src.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InventarySystem.Api.Modules.Inventory.Presentation.Controllers;

[ApiController]
[Route("api/companies/{companyId:int}/products")]
public class CompanyProductController(ICompanyProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(int companyId)
    {
        var result = await service.GetAllByCompanyAsync(companyId);
        return Ok(ApiResponse<IEnumerable<CompanyProductDto>>.Ok(result));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int companyId, int id)
    {
        var result = await service.GetByIdAsync(id, companyId);
        if (result is null) return NotFound(ApiResponse<object>.Fail($"Product {id} not found"));
        return Ok(ApiResponse<CompanyProductDto>.Ok(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create(int companyId, [FromBody] CompanyProductCreateDto dto)
    {
        dto.CompanyId = companyId;
        var result = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { companyId, id = result.Id }, ApiResponse<CompanyProductDto>.Ok(result));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Deactivate(int companyId, int id)
    {
        try
        {
            await service.DeactivateAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound(ApiResponse<object>.Fail($"Product {id} not found"));
        }
    }
}