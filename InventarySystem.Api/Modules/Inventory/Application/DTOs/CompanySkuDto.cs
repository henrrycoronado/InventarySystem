namespace InventarySystem.Api.Modules.Inventory.Application.DTOs;

public class CompanySkuDto
{
    public int Id { get; set; }
    public int CompanyProductId { get; set; }
    public string InternalSku { get; set; } = null!;
    public decimal RetailPrice { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class CompanySkuCreateDto
{
    public int CompanyProductId { get; set; }
    public string InternalSku { get; set; } = null!;
    public decimal RetailPrice { get; set; }
}