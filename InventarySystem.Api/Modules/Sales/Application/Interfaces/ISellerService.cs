using InventarySystem.Api.Modules.Sales.Application.DTOs;

namespace InventarySystem.Api.Modules.Sales.Application.Interfaces;

public interface ISellerService
{
    Task<IEnumerable<SellerDto>> GetAllByCompanyAsync(int companyId);
    Task<SellerDto?> GetByIdAsync(int id, int companyId);
    Task<SellerDto> CreateAsync(SellerCreateDto dto);
    Task DeactivateAsync(int id);
}