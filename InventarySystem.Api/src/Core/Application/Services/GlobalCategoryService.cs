using InventarySystem.Api.src.Core.Application.DTOs;
using InventarySystem.Api.src.Core.Application.Interfaces;
using InventarySystem.Api.src.Core.Domain.Entities;
using InventarySystem.Api.src.Core.Domain.Interfaces;

namespace InventarySystem.Api.src.Core.Application.Services;

public class GlobalCategoryService(IGlobalCategoryRepository repository) : IGlobalCategoryService
{
    public async Task<IEnumerable<GlobalCategoryDto>> GetAllActiveAsync()
    {
        var items = await repository.GetAllActiveAsync();
        return items.Select(c => new GlobalCategoryDto { Id = c.Id, Name = c.Name, CreatedAt = c.CreatedAt });
    }

    public async Task<GlobalCategoryDto?> GetByIdAsync(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item is null) return null;
        return new GlobalCategoryDto { Id = item.Id, Name = item.Name, CreatedAt = item.CreatedAt };
    }

    public async Task<GlobalCategoryDto> CreateAsync(GlobalCategoryCreateDto dto)
    {
        var entity = GlobalCategoryEntity.Create(dto.Name);
        var created = await repository.CreateAsync(entity);
        return new GlobalCategoryDto { Id = created.Id, Name = created.Name, CreatedAt = created.CreatedAt };
    }

    public async Task DeactivateAsync(int id) => await repository.DeactivateAsync(id);
}