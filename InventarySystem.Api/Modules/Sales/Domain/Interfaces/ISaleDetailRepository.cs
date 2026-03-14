using InventarySystem.Api.Modules.Sales.Domain.Entities;

namespace InventarySystem.Api.Modules.Sales.Domain.Interfaces;

public interface ISaleDetailRepository
{
    Task<IEnumerable<SaleDetailEntity>> GetAllBySaleAsync(int saleId);
    Task<SaleDetailEntity> CreateAsync(SaleDetailEntity entity);
}