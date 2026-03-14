namespace InventarySystem.Api.Modules.Sales.Application.DTOs;

public class SaleDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int WarehouseId { get; set; }
    public int? SellerId { get; set; }
    public int? CustomerId { get; set; }
    public int StatusId { get; set; }
    public DateTime SaleDate { get; set; }
    public string? Notes { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class SaleCreateDto
{
    public int CompanyId { get; set; }
    public int WarehouseId { get; set; }
    public int? SellerId { get; set; }
    public int? CustomerId { get; set; }
    public string? Notes { get; set; }
    public List<SaleDetailCreateDto> Details { get; set; } = [];
}

public class SaleDetailCreateDto
{
    public int SkuId { get; set; }
    public int? BatchId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}