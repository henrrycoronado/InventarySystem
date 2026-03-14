using InventarySystem.Api.Modules.Inventory.Application.DTOs;
using InventarySystem.Api.Modules.Inventory.Application.Interfaces;
using InventarySystem.Api.src.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InventarySystem.Api.Modules.Inventory.Presentation.Controllers;

[ApiController]
[Route("api/companies/{companyId:int}/movements")]
public class MovementController(IMovementService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(int companyId)
    {
        var result = await service.GetAllByCompanyAsync(companyId);
        return Ok(ApiResponse<IEnumerable<MovementDto>>.Ok(result));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int companyId, int id)
    {
        var result = await service.GetByIdAsync(id);
        if (result is null) return NotFound(ApiResponse<object>.Fail($"Movement {id} not found"));
        return Ok(ApiResponse<MovementDto>.Ok(result));
    }

    [HttpPost("incoming")]
    public async Task<IActionResult> RegisterIncoming(int companyId, [FromBody] MovementCreateDto dto)
    {
        try
        {
            dto.CompanyId = companyId;
            var result = await service.RegisterIncomingAsync(dto);
            return CreatedAtAction(nameof(GetById), new { companyId, id = result.Id }, ApiResponse<MovementDto>.Ok(result));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ApiResponse<object>.Fail(ex.Message));
        }
    }

    [HttpPost("outgoing")]
    public async Task<IActionResult> RegisterOutgoing(int companyId, [FromBody] MovementCreateDto dto)
    {
        try
        {
            dto.CompanyId = companyId;
            var result = await service.RegisterOutgoingAsync(dto);
            return CreatedAtAction(nameof(GetById), new { companyId, id = result.Id }, ApiResponse<MovementDto>.Ok(result));
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ApiResponse<object>.Fail(ex.Message));
        }
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
            return NotFound(ApiResponse<object>.Fail($"Movement {id} not found"));
        }
    }
}