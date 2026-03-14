using InventarySystem.Api.Modules.Inventory.Application.DTOs;

namespace InventarySystem.Api.Modules.Inventory.Application.Interfaces;

public interface IMovementService
{
    Task<IEnumerable<MovementDto>> GetAllByCompanyAsync(int companyId);
    Task<MovementDto?> GetByIdAsync(int id);
    Task<MovementDto> RegisterIncomingAsync(MovementCreateDto dto);
    Task<MovementDto> RegisterOutgoingAsync(MovementCreateDto dto);
    Task DeactivateAsync(int id);
}