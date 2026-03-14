using InventarySystem.Api.Modules.Inventory.Domain.Entities;

namespace InventarySystem.Api.Modules.Inventory.Domain.Interfaces;

public interface ICompanySkuRepository
{
    Task<IEnumerable<CompanySkuEntity>> GetAllByProductAsync(int companyProductId);
    Task<CompanySkuEntity?> GetByIdAsync(int id);
    Task<CompanySkuEntity> CreateAsync(CompanySkuEntity entity);
    Task DeactivateAsync(int id);
}