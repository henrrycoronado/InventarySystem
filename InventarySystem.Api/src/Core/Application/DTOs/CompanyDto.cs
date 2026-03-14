namespace InventarySystem.Api.src.Core.Application.DTOs;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
}

public class CompanyCreateDto
{
    public string Name { get; set; } = null!;
}