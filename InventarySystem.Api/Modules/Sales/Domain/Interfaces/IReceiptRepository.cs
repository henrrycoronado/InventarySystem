using InventarySystem.Api.Modules.Sales.Domain.Entities;

namespace InventarySystem.Api.Modules.Sales.Domain.Interfaces;

public interface IReceiptRepository
{
    Task<ReceiptEntity?> GetBySaleAsync(int saleId);
    Task<ReceiptEntity> CreateAsync(ReceiptEntity entity);
}