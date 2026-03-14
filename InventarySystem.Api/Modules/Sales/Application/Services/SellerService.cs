using InventarySystem.Api.Modules.Sales.Application.DTOs;
using InventarySystem.Api.Modules.Sales.Application.Interfaces;
using InventarySystem.Api.Modules.Sales.Domain.Entities;
using InventarySystem.Api.Modules.Sales.Domain.Interfaces;

namespace InventarySystem.Api.Modules.Sales.Application.Services;

public class SellerService(ISellerRepository repository) : ISellerService
{
    public async Task<IEnumerable<SellerDto>> GetAllByCompanyAsync(int companyId)
    {
        var items = await repository.GetAllByCompanyAsync(companyId);
        return items.Select(Map);
    }

    public async Task<SellerDto?> GetByIdAsync(int id, int companyId)
    {
        var item = await repository.GetByIdAsync(id, companyId);
        return item is null ? null : Map(item);
    }

    public async Task<SellerDto> CreateAsync(SellerCreateDto dto)
    {
        var entity = SellerEntity.Create(dto.CompanyId, dto.Name, dto.Phone);
        var created = await repository.CreateAsync(entity);
        return Map(created);
    }

    public async Task DeactivateAsync(int id) => await repository.DeactivateAsync(id);

    private static SellerDto Map(SellerEntity e) => new()
    {
        Id = e.Id, CompanyId = e.CompanyId, Name = e.Name,
        Phone = e.Phone, CreatedAt = e.CreatedAt
    };
}