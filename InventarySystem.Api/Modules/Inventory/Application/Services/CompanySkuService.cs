using InventarySystem.Api.Modules.Inventory.Application.DTOs;
using InventarySystem.Api.Modules.Inventory.Application.Interfaces;
using InventarySystem.Api.Modules.Inventory.Domain.Entities;
using InventarySystem.Api.Modules.Inventory.Domain.Interfaces;

namespace InventarySystem.Api.Modules.Inventory.Application.Services;

public class CompanySkuService(ICompanySkuRepository repository) : ICompanySkuService
{
    public async Task<IEnumerable<CompanySkuDto>> GetAllByProductAsync(int companyProductId)
    {
        var items = await repository.GetAllByProductAsync(companyProductId);
        return items.Select(Map);
    }

    public async Task<CompanySkuDto?> GetByIdAsync(int id)
    {
        var item = await repository.GetByIdAsync(id);
        return item is null ? null : Map(item);
    }

    public async Task<CompanySkuDto> CreateAsync(CompanySkuCreateDto dto)
    {
        var entity = CompanySkuEntity.Create(dto.CompanyProductId, dto.InternalSku, dto.RetailPrice);
        var created = await repository.CreateAsync(entity);
        return Map(created);
    }

    public async Task DeactivateAsync(int id) => await repository.DeactivateAsync(id);

    private static CompanySkuDto Map(CompanySkuEntity e) => new()
    {
        Id = e.Id, CompanyProductId = e.CompanyProductId,
        InternalSku = e.InternalSku, RetailPrice = e.RetailPrice, CreatedAt = e.CreatedAt
    };
}