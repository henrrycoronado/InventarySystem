using InventarySystem.Api.Modules.Inventory.Domain.Entities;

namespace InventarySystem.Api.Modules.Inventory.Domain.Interfaces;

public interface ICompanyProductRepository
{
    Task<IEnumerable<CompanyProductEntity>> GetAllByCompanyAsync(int companyId);
    Task<CompanyProductEntity?> GetByIdAsync(int id, int companyId);
    Task<CompanyProductEntity> CreateAsync(CompanyProductEntity entity);
    Task DeactivateAsync(int id);
}