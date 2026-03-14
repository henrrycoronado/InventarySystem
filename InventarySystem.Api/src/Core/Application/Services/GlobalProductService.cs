using InventarySystem.Api.src.Core.Application.DTOs;
using InventarySystem.Api.src.Core.Application.Interfaces;
using InventarySystem.Api.src.Core.Domain.Entities;
using InventarySystem.Api.src.Core.Domain.Interfaces;

namespace InventarySystem.Api.src.Core.Application.Services;

public class GlobalProductService(IGlobalProductRepository repository) : IGlobalProductService
{
    public async Task<IEnumerable<GlobalProductDto>> GetAllActiveAsync()
    {
        var items = await repository.GetAllActiveAsync();
        return items.Select(Map);
    }

    public async Task<GlobalProductDto?> GetByIdAsync(int id)
    {
        var item = await repository.GetByIdAsync(id);
        return item is null ? null : Map(item);
    }

    public async Task<GlobalProductDto?> GetByUpcAsync(string upc)
    {
        var item = await repository.GetByUpcAsync(upc);
        return item is null ? null : Map(item);
    }

    public async Task<GlobalProductDto> CreateAsync(GlobalProductCreateDto dto)
    {
        var entity = GlobalProductEntity.Create(dto.CategoryId, dto.Name, dto.Brand, dto.UpcBarcode);
        var created = await repository.CreateAsync(entity);
        return Map(created);
    }

    public async Task DeactivateAsync(int id) => await repository.DeactivateAsync(id);

    private static GlobalProductDto Map(GlobalProductEntity e) => new()
    {
        Id = e.Id,
        CategoryId = e.CategoryId,
        Name = e.Name,
        Brand = e.Brand,
        UpcBarcode = e.UpcBarcode,
        CreatedAt = e.CreatedAt
    };
}