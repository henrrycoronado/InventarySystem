using InventarySystem.Api.Modules.Sales.Application.DTOs;

namespace InventarySystem.Api.Modules.Sales.Application.Interfaces;

public interface ISaleService
{
    Task<IEnumerable<SaleDto>> GetAllByCompanyAsync(int companyId);
    Task<SaleDto?> GetByIdAsync(int id);
    Task<SaleDto> CreateAsync(SaleCreateDto dto);
    Task<SaleDto> ConfirmAsync(int id);
    Task<SaleDto> CancelAsync(int id);
    Task DeactivateAsync(int id);
}