using InventarySystem.Api.src.Core.Domain.Entities;

namespace InventarySystem.Api.src.Core.Domain.Interfaces;

public interface ICompanyRepository
{
    Task<IEnumerable<CompanyEntity>> GetAllActiveAsync();
    Task<CompanyEntity?> GetByIdAsync(int id);
    Task<CompanyEntity> CreateAsync(CompanyEntity company);
    Task DeactivateAsync(int id);
}