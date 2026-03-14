using InventarySystem.Api.Modules.Sales.Application.DTOs;
using InventarySystem.Api.Modules.Sales.Application.Interfaces;
using InventarySystem.Api.Modules.Sales.Domain.Entities;
using InventarySystem.Api.Modules.Sales.Domain.Interfaces;

namespace InventarySystem.Api.Modules.Sales.Application.Services;

public class ReceiptService(
    IReceiptRepository receiptRepository,
    ISaleDetailRepository saleDetailRepository) : IReceiptService
{
    public async Task<ReceiptDto?> GetBySaleAsync(int saleId)
    {
        var item = await receiptRepository.GetBySaleAsync(saleId);
        return item is null ? null : Map(item);
    }

    public async Task<ReceiptDto> GenerateAsync(int saleId)
    {
        var details = await saleDetailRepository.GetAllBySaleAsync(saleId);
        var total = details.Sum(d => d.Quantity * d.UnitPrice);

        var entity = ReceiptEntity.Create(saleId, total);
        var created = await receiptRepository.CreateAsync(entity);
        return Map(created);
    }

    private static ReceiptDto Map(ReceiptEntity e) => new()
    {
        Id = e.Id, SaleId = e.SaleId, TotalAmount = e.TotalAmount,
        IssuedAt = e.IssuedAt, CreatedAt = e.CreatedAt
    };
}