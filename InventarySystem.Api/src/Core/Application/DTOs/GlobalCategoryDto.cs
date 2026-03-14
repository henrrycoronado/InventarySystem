namespace InventarySystem.Api.src.Core.Application.DTOs;

public class GlobalCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
}

public class GlobalCategoryCreateDto
{
    public string Name { get; set; } = null!;
}