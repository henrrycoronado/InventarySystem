namespace InventarySystem.Api.Modules.Inventory.Application.DTOs;

public class KardexDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int WarehouseId { get; set; }
    public int SkuId { get; set; }
    public int? BatchId { get; set; }
    public int TypeId { get; set; }
    public decimal Quantity { get; set; }
    public decimal BalanceAfter { get; set; }
    public DateTime CreatedAt { get; set; }
}