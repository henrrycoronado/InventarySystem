namespace InventarySystem.Api.Modules.Inventory.Domain.Entities;

public class CompanySkuEntity
{
    public int Id { get; private set; }
    public int CompanyProductId { get; private set; }
    public string InternalSku { get; private set; } = null!;
    public decimal RetailPrice { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal CompanySkuEntity() { }

    public static CompanySkuEntity Create(int companyProductId, string internalSku, decimal retailPrice) =>
        new() { CompanyProductId = companyProductId, InternalSku = internalSku, RetailPrice = retailPrice, IsActive = true, CreatedAt = DateTime.Now };

    public void Deactivate() => IsActive = false;

    internal CompanySkuEntity Init(int id, int companyProductId, string internalSku, decimal retailPrice, bool isActive, DateTime createdAt)
    {
        Id = id; CompanyProductId = companyProductId; InternalSku = internalSku;
        RetailPrice = retailPrice; IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}