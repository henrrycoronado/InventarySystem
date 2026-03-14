using InventarySystem.Api.Modules.Inventory.Domain.Entities;
using InventarySystem.Api.Modules.Inventory.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Inventory.Infrastructure.Repositories;

public class KardexRepository(AppDbContext db) : IKardexRepository
{
    public async Task<IEnumerable<KardexEntity>> GetBySkuAndWarehouseAsync(int skuId, int warehouseId)
    {
        var models = await db.Kardices
            .Where(k => k.SkuId == skuId && k.WarehouseId == warehouseId)
            .OrderBy(k => k.CreatedAt)
            .ToListAsync();
        return models.Select(Map);
    }

    public async Task<KardexEntity> CreateAsync(KardexEntity entity)
    {
        var model = new Kardex
        {
            CompanyId = entity.CompanyId,
            WarehouseId = entity.WarehouseId,
            SkuId = entity.SkuId,
            BatchId = entity.BatchId,
            MovementDetailId = entity.MovementDetailId,
            TypeId = entity.TypeId,
            Quantity = entity.Quantity,
            BalanceAfter = entity.BalanceAfter,
            IsActive = true,
            CreatedAt = entity.CreatedAt
        };
        db.Kardices.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    private static KardexEntity Map(Kardex m) =>
        new KardexEntity().Init(m.Id, m.CompanyId, m.WarehouseId, m.SkuId, m.BatchId, m.MovementDetailId, m.TypeId, m.Quantity, m.BalanceAfter, m.CreatedAt ?? DateTime.Now);
}