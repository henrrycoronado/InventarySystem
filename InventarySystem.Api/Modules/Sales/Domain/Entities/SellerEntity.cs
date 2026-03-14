namespace InventarySystem.Api.Modules.Sales.Domain.Entities;

public class SellerEntity
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Phone { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal SellerEntity() { }

    public static SellerEntity Create(int companyId, string name, string? phone) =>
        new() { CompanyId = companyId, Name = name, Phone = phone, IsActive = true, CreatedAt = DateTime.Now };

    public void Deactivate() => IsActive = false;

    internal SellerEntity Init(int id, int companyId, string name, string? phone, bool isActive, DateTime createdAt)
    {
        Id = id; CompanyId = companyId; Name = name; Phone = phone; IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}