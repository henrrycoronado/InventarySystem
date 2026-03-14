namespace InventarySystem.Api.Modules.Inventory.Application.DTOs;

public class CompanyProductDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int GlobalProductId { get; set; }
    public string? LocalNameAlias { get; set; }
    public decimal WholesalePrice { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class CompanyProductCreateDto
{
    public int CompanyId { get; set; }
    public int GlobalProductId { get; set; }
    public string? LocalNameAlias { get; set; }
    public decimal WholesalePrice { get; set; }
}