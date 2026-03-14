namespace InventarySystem.Api.Modules.Inventory.Application.DTOs;

public class StockDto
{
    public int Id { get; set; }
    public int WarehouseId { get; set; }
    public int SkuId { get; set; }
    public int? BatchId { get; set; }
    public decimal Quantity { get; set; }
    public decimal ReservedQuantity { get; set; }
    public decimal AvailableQuantity { get; set; }
    public DateTime? LastUpdated { get; set; }
}

public class StockCreateDto
{
    public int WarehouseId { get; set; }
    public int SkuId { get; set; }
    public int? BatchId { get; set; }
    public decimal Quantity { get; set; }
}