namespace InventarySystem.Api.Modules.Sales.Domain.Entities;

public class CustomerEntity
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Phone { get; private set; }
    public string? Email { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal CustomerEntity() { }

    public static CustomerEntity Create(int companyId, string name, string? phone, string? email) =>
        new() { CompanyId = companyId, Name = name, Phone = phone, Email = email, IsActive = true, CreatedAt = DateTime.Now };

    public void Deactivate() => IsActive = false;

    internal CustomerEntity Init(int id, int companyId, string name, string? phone, string? email, bool isActive, DateTime createdAt)
    {
        Id = id; CompanyId = companyId; Name = name; Phone = phone;
        Email = email; IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}