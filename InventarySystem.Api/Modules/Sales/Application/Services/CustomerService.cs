using InventarySystem.Api.Modules.Sales.Application.DTOs;
using InventarySystem.Api.Modules.Sales.Application.Interfaces;
using InventarySystem.Api.Modules.Sales.Domain.Entities;
using InventarySystem.Api.Modules.Sales.Domain.Interfaces;

namespace InventarySystem.Api.Modules.Sales.Application.Services;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    public async Task<IEnumerable<CustomerDto>> GetAllByCompanyAsync(int companyId)
    {
        var items = await repository.GetAllByCompanyAsync(companyId);
        return items.Select(Map);
    }

    public async Task<CustomerDto?> GetByIdAsync(int id, int companyId)
    {
        var item = await repository.GetByIdAsync(id, companyId);
        return item is null ? null : Map(item);
    }

    public async Task<CustomerDto> CreateAsync(CustomerCreateDto dto)
    {
        var entity = CustomerEntity.Create(dto.CompanyId, dto.Name, dto.Phone, dto.Email);
        var created = await repository.CreateAsync(entity);
        return Map(created);
    }

    public async Task DeactivateAsync(int id) => await repository.DeactivateAsync(id);

    private static CustomerDto Map(CustomerEntity e) => new()
    {
        Id = e.Id, CompanyId = e.CompanyId, Name = e.Name,
        Phone = e.Phone, Email = e.Email, CreatedAt = e.CreatedAt
    };
}