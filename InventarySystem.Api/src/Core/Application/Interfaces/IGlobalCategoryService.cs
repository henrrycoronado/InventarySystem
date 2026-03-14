using InventarySystem.Api.src.Core.Application.DTOs;

namespace InventarySystem.Api.src.Core.Application.Interfaces;

public interface IGlobalCategoryService
{
    Task<IEnumerable<GlobalCategoryDto>> GetAllActiveAsync();
    Task<GlobalCategoryDto?> GetByIdAsync(int id);
    Task<GlobalCategoryDto> CreateAsync(GlobalCategoryCreateDto dto);
    Task DeactivateAsync(int id);
}