using InventarySystem.Api.Modules.Sales.Application.DTOs;

namespace InventarySystem.Api.Modules.Sales.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllByCompanyAsync(int companyId);
    Task<CustomerDto?> GetByIdAsync(int id, int companyId);
    Task<CustomerDto> CreateAsync(CustomerCreateDto dto);
    Task DeactivateAsync(int id);
}