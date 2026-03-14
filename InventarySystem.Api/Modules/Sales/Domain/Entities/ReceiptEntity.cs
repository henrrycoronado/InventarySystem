namespace InventarySystem.Api.Modules.Sales.Domain.Entities;

public class ReceiptEntity
{
    public int Id { get; private set; }
    public int SaleId { get; private set; }
    public decimal TotalAmount { get; private set; }
    public DateTime IssuedAt { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal ReceiptEntity() { }

    public static ReceiptEntity Create(int saleId, decimal totalAmount) =>
        new() { SaleId = saleId, TotalAmount = totalAmount, IssuedAt = DateTime.Now, IsActive = true, CreatedAt = DateTime.Now };

    internal ReceiptEntity Init(int id, int saleId, decimal totalAmount, DateTime issuedAt, bool isActive, DateTime createdAt)
    {
        Id = id; SaleId = saleId; TotalAmount = totalAmount;
        IssuedAt = issuedAt; IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}