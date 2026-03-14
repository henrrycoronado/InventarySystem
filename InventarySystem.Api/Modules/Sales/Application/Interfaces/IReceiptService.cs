using InventarySystem.Api.Modules.Sales.Application.DTOs;

namespace InventarySystem.Api.Modules.Sales.Application.Interfaces;

public interface IReceiptService
{
    Task<ReceiptDto?> GetBySaleAsync(int saleId);
    Task<ReceiptDto> GenerateAsync(int saleId);
}