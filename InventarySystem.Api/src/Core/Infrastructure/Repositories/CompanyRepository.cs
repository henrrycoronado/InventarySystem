using InventarySystem.Api.src.Core.Domain.Entities;
using InventarySystem.Api.src.Core.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.src.Core.Infrastructure.Repositories;

public class CompanyRepository(AppDbContext db) : ICompanyRepository
{
    public async Task<IEnumerable<CompanyEntity>> GetAllActiveAsync()
    {
        var models = await db.Companies
            .Where(c => c.IsActive == true)
            .ToListAsync();

        return models.Select(c => new CompanyEntity().Init(c.Id, c.Name!, c.IsActive ?? true, c.CreatedAt ?? DateTime.UtcNow));
    }

    public async Task<CompanyEntity?> GetByIdAsync(int id)
    {
        var model = await db.Companies
            .FirstOrDefaultAsync(c => c.Id == id && c.IsActive == true);

        return model is null ? null : new CompanyEntity().Init(model.Id, model.Name!, model.IsActive ?? true, model.CreatedAt ?? DateTime.UtcNow);
    }

    public async Task<CompanyEntity> CreateAsync(CompanyEntity entity)
    {
        var model = new Models.Company
        {
            Name = entity.Name,
            IsActive = entity.IsActive,
            CreatedAt = entity.CreatedAt
        };

        db.Companies.Add(model);
        await db.SaveChangesAsync();

        return new CompanyEntity().Init(model.Id, model.Name!, model.IsActive ?? true, model.CreatedAt ?? DateTime.UtcNow);
    }

    public async Task DeactivateAsync(int id)
    {
        var model = await db.Companies.FindAsync(id);
        if (model is null) throw new KeyNotFoundException($"Company {id} not found");
        model.IsActive = false;
        await db.SaveChangesAsync();
    }
}