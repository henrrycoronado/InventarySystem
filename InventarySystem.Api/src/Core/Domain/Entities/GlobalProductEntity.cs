namespace InventarySystem.Api.src.Core.Domain.Entities;

public class GlobalProductEntity
{
    public int Id { get; private set; }
    public int? CategoryId { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Brand { get; private set; }
    public string? UpcBarcode { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal GlobalProductEntity() { }

    public static GlobalProductEntity Create(int? categoryId, string name, string? brand, string? upcBarcode) =>
        new() { CategoryId = categoryId, Name = name, Brand = brand, UpcBarcode = upcBarcode, IsActive = true, CreatedAt = DateTime.Now };

    public void Deactivate() => IsActive = false;

    internal GlobalProductEntity Init(int id, int? categoryId, string name, string? brand, string? upcBarcode, bool isActive, DateTime createdAt)
    {
        Id = id; CategoryId = categoryId; Name = name; Brand = brand; UpcBarcode = upcBarcode; IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}