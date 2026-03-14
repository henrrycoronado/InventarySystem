using InventarySystem.Api.Modules.Sales.Domain.Entities;
using InventarySystem.Api.Modules.Sales.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Sales.Infrastructure.Repositories;

public class CustomerRepository(AppDbContext db) : ICustomerRepository
{
    public async Task<IEnumerable<CustomerEntity>> GetAllByCompanyAsync(int companyId)
    {
        var models = await db.Customers
            .Where(c => c.CompanyId == companyId && c.IsActive == true)
            .ToListAsync();
        return models.Select(Map);
    }

    public async Task<CustomerEntity?> GetByIdAsync(int id, int companyId)
    {
        var model = await db.Customers
            .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == companyId && c.IsActive == true);
        return model is null ? null : Map(model);
    }

    public async Task<CustomerEntity> CreateAsync(CustomerEntity entity)
    {
        var model = new Customer
        {
            CompanyId = entity.CompanyId,
            Name = entity.Name,
            Phone = entity.Phone,
            Email = entity.Email,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };
        db.Customers.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    public async Task DeactivateAsync(int id)
    {
        var model = await db.Customers.FindAsync(id);
        if (model is null) throw new KeyNotFoundException($"Customer {id} not found");
        model.IsActive = false;
        await db.SaveChangesAsync();
    }

    private static CustomerEntity Map(Customer m) =>
        new CustomerEntity().Init(m.Id, m.CompanyId, m.Name!, m.Phone, m.Email, m.IsActive ?? true, m.CreatedAt ?? DateTime.Now);
}