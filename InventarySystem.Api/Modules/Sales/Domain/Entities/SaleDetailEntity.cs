namespace InventarySystem.Api.Modules.Sales.Domain.Entities;

public class SaleDetailEntity
{
    public int Id { get; private set; }
    public int SaleId { get; private set; }
    public int SkuId { get; private set; }
    public int? BatchId { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal SaleDetailEntity() { }

    public static SaleDetailEntity Create(int saleId, int skuId, int? batchId, decimal quantity, decimal unitPrice) =>
        new() { SaleId = saleId, SkuId = skuId, BatchId = batchId, Quantity = quantity, UnitPrice = unitPrice, IsActive = true, CreatedAt = DateTime.Now };

    internal SaleDetailEntity Init(int id, int saleId, int skuId, int? batchId, decimal quantity, decimal unitPrice, bool isActive, DateTime createdAt)
    {
        Id = id; SaleId = saleId; SkuId = skuId; BatchId = batchId;
        Quantity = quantity; UnitPrice = unitPrice; IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}