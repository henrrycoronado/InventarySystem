namespace InventarySystem.Api.Modules.Sales.Application.DTOs;

public class ReceiptDto
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime IssuedAt { get; set; }
    public DateTime? CreatedAt { get; set; }
}