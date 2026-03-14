namespace InventarySystem.Api.Modules.Inventory.Domain.Entities;

public class CompanyProductEntity
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public int GlobalProductId { get; private set; }
    public string? LocalNameAlias { get; private set; }
    public decimal WholesalePrice { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal CompanyProductEntity() { }

    public static CompanyProductEntity Create(int companyId, int globalProductId, string? localNameAlias, decimal wholesalePrice) =>
        new() { CompanyId = companyId, GlobalProductId = globalProductId, LocalNameAlias = localNameAlias, WholesalePrice = wholesalePrice, IsActive = true, CreatedAt = DateTime.Now };

    public void Deactivate() => IsActive = false;

    internal CompanyProductEntity Init(int id, int companyId, int globalProductId, string? localNameAlias, decimal wholesalePrice, bool isActive, DateTime createdAt)
    {
        Id = id; CompanyId = companyId; GlobalProductId = globalProductId;
        LocalNameAlias = localNameAlias; WholesalePrice = wholesalePrice;
        IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}