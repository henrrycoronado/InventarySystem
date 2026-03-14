using InventarySystem.Api.src.Core.Domain.Entities;

namespace InventarySystem.Api.src.Core.Domain.Interfaces;

public interface IGlobalProductRepository
{
    Task<IEnumerable<GlobalProductEntity>> GetAllActiveAsync();
    Task<GlobalProductEntity?> GetByIdAsync(int id);
    Task<GlobalProductEntity?> GetByUpcAsync(string upc);
    Task<GlobalProductEntity> CreateAsync(GlobalProductEntity product);
    Task DeactivateAsync(int id);
}