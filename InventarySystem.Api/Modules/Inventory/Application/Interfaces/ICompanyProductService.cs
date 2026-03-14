using InventarySystem.Api.Modules.Inventory.Application.DTOs;

namespace InventarySystem.Api.Modules.Inventory.Application.Interfaces;

public interface ICompanyProductService
{
    Task<IEnumerable<CompanyProductDto>> GetAllByCompanyAsync(int companyId);
    Task<CompanyProductDto?> GetByIdAsync(int id, int companyId);
    Task<CompanyProductDto> CreateAsync(CompanyProductCreateDto dto);
    Task DeactivateAsync(int id);
}