using InventarySystem.Api.src.Core.Application.DTOs;
using InventarySystem.Api.src.Core.Application.Interfaces;
using InventarySystem.Api.src.Core.Domain.Entities;
using InventarySystem.Api.src.Core.Domain.Interfaces;

namespace InventarySystem.Api.src.Core.Application.Services;

public class WarehouseService(IWarehouseRepository repository) : IWarehouseService
{
    public async Task<IEnumerable<WarehouseDto>> GetAllByCompanyAsync(int companyId)
    {
        var warehouses = await repository.GetAllByCompanyAsync(companyId);
        return warehouses.Select(w => new WarehouseDto { Id = w.Id, CompanyId = w.CompanyId, Name = w.Name, CreatedAt = w.CreatedAt });
    }

    public async Task<WarehouseDto?> GetByIdAsync(int id, int companyId)
    {
        var warehouse = await repository.GetByIdAsync(id, companyId);
        if (warehouse is null) return null;
        return new WarehouseDto { Id = warehouse.Id, CompanyId = warehouse.CompanyId, Name = warehouse.Name, CreatedAt = warehouse.CreatedAt };
    }

    public async Task<WarehouseDto> CreateAsync(WarehouseCreateDto dto)
    {
        var entity = WarehouseEntity.Create(dto.CompanyId, dto.Name);
        var created = await repository.CreateAsync(entity);
        return new WarehouseDto { Id = created.Id, CompanyId = created.CompanyId, Name = created.Name, CreatedAt = created.CreatedAt };
    }

    public async Task DeactivateAsync(int id) => await repository.DeactivateAsync(id);
}