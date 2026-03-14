namespace InventarySystem.Api.src.Core.Application.DTOs;

public class WarehouseDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
}

public class WarehouseCreateDto
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
}