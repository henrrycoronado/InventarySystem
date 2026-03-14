using InventarySystem.Api.src.Core.Application.DTOs;
using InventarySystem.Api.src.Core.Application.Interfaces;
using InventarySystem.Api.src.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InventarySystem.Api.src.Core.Presentation.Controllers;

[ApiController]
[Route("api/global-categories")]
public class GlobalCategoryController(IGlobalCategoryService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await service.GetAllActiveAsync();
        return Ok(ApiResponse<IEnumerable<GlobalCategoryDto>>.Ok(result));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await service.GetByIdAsync(id);
        if (result is null) return NotFound(ApiResponse<object>.Fail($"GlobalCategory {id} not found"));
        return Ok(ApiResponse<GlobalCategoryDto>.Ok(result));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GlobalCategoryCreateDto dto)
    {
        var result = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<GlobalCategoryDto>.Ok(result));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Deactivate(int id)
    {
        try
        {
            await service.DeactivateAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound(ApiResponse<object>.Fail($"GlobalCategory {id} not found"));
        }
    }
}