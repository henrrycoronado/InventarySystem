using InventarySystem.Api.Modules.Sales.Domain.Entities;

namespace InventarySystem.Api.Modules.Sales.Domain.Interfaces;

public interface ISellerRepository
{
    Task<IEnumerable<SellerEntity>> GetAllByCompanyAsync(int companyId);
    Task<SellerEntity?> GetByIdAsync(int id, int companyId);
    Task<SellerEntity> CreateAsync(SellerEntity entity);
    Task DeactivateAsync(int id);
}