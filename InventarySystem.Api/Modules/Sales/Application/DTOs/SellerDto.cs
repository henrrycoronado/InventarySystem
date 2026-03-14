namespace InventarySystem.Api.Modules.Sales.Application.DTOs;

public class SellerDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class SellerCreateDto
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
}