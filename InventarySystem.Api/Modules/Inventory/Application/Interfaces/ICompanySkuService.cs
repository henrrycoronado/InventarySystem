using InventarySystem.Api.Modules.Inventory.Application.DTOs;

namespace InventarySystem.Api.Modules.Inventory.Application.Interfaces;

public interface ICompanySkuService
{
    Task<IEnumerable<CompanySkuDto>> GetAllByProductAsync(int companyProductId);
    Task<CompanySkuDto?> GetByIdAsync(int id);
    Task<CompanySkuDto> CreateAsync(CompanySkuCreateDto dto);
    Task DeactivateAsync(int id);
}