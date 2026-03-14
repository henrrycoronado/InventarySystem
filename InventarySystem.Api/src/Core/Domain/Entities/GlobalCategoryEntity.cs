namespace InventarySystem.Api.src.Core.Domain.Entities;

public class GlobalCategoryEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal GlobalCategoryEntity() { }

    public static GlobalCategoryEntity Create(string name) =>
        new() { Name = name, IsActive = true, CreatedAt = DateTime.Now };

    public void Deactivate() => IsActive = false;

    internal GlobalCategoryEntity Init(int id, string name, bool isActive, DateTime createdAt)
    {
        Id = id; Name = name; IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}