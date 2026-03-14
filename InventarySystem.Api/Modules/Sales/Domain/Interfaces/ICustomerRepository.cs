using InventarySystem.Api.Modules.Sales.Domain.Entities;

namespace InventarySystem.Api.Modules.Sales.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerEntity>> GetAllByCompanyAsync(int companyId);
    Task<CustomerEntity?> GetByIdAsync(int id, int companyId);
    Task<CustomerEntity> CreateAsync(CustomerEntity entity);
    Task DeactivateAsync(int id);
}