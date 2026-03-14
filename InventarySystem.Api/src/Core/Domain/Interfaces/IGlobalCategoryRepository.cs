using InventarySystem.Api.src.Core.Domain.Entities;

namespace InventarySystem.Api.src.Core.Domain.Interfaces;

public interface IGlobalCategoryRepository
{
    Task<IEnumerable<GlobalCategoryEntity>> GetAllActiveAsync();
    Task<GlobalCategoryEntity?> GetByIdAsync(int id);
    Task<GlobalCategoryEntity> CreateAsync(GlobalCategoryEntity category);
    Task DeactivateAsync(int id);
}