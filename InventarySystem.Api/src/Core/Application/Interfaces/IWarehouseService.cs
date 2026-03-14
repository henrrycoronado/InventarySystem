using InventarySystem.Api.src.Core.Application.DTOs;

namespace InventarySystem.Api.src.Core.Application.Interfaces;

public interface IWarehouseService
{
    Task<IEnumerable<WarehouseDto>> GetAllByCompanyAsync(int companyId);
    Task<WarehouseDto?> GetByIdAsync(int id, int companyId);
    Task<WarehouseDto> CreateAsync(WarehouseCreateDto dto);
    Task DeactivateAsync(int id);
}