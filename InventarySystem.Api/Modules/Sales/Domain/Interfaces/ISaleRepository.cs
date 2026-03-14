using InventarySystem.Api.Modules.Sales.Domain.Entities;

namespace InventarySystem.Api.Modules.Sales.Domain.Interfaces;

public interface ISaleRepository
{
    Task<IEnumerable<SaleEntity>> GetAllByCompanyAsync(int companyId);
    Task<SaleEntity?> GetByIdAsync(int id);
    Task<SaleEntity> CreateAsync(SaleEntity entity);
    Task UpdateStatusAsync(int id, int statusId);
    Task DeactivateAsync(int id);
}