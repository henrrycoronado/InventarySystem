using InventarySystem.Api.src.Core.Application.DTOs;
using InventarySystem.Api.src.Core.Application.Interfaces;
using InventarySystem.Api.src.Core.Domain.Entities;
using InventarySystem.Api.src.Core.Domain.Interfaces;

namespace InventarySystem.Api.src.Core.Application.Services;

public class CompanyService(ICompanyRepository repository) : ICompanyService
{
    public async Task<IEnumerable<CompanyDto>> GetAllActiveAsync()
    {
        var companies = await repository.GetAllActiveAsync();
        return companies.Select(c => new CompanyDto { Id = c.Id, Name = c.Name, CreatedAt = c.CreatedAt });
    }

    public async Task<CompanyDto?> GetByIdAsync(int id)
    {
        var company = await repository.GetByIdAsync(id);
        if (company is null) return null;
        return new CompanyDto { Id = company.Id, Name = company.Name, CreatedAt = company.CreatedAt };
    }

    public async Task<CompanyDto> CreateAsync(CompanyCreateDto dto)
    {
        var entity = CompanyEntity.Create(dto.Name);
        var created = await repository.CreateAsync(entity);
        return new CompanyDto { Id = created.Id, Name = created.Name, CreatedAt = created.CreatedAt };
    }

    public async Task DeactivateAsync(int id) => await repository.DeactivateAsync(id);
}