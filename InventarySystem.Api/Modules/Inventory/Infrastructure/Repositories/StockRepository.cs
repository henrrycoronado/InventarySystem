using InventarySystem.Api.Modules.Inventory.Domain.Entities;
using InventarySystem.Api.Modules.Inventory.Domain.Interfaces;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarySystem.Api.Modules.Inventory.Infrastructure.Repositories;

public class StockRepository(AppDbContext db) : IStockRepository
{
    public async Task<IEnumerable<StockEntity>> GetAllByWarehouseAsync(int warehouseId)
    {
        var models = await db.Stocks
            .Where(s => s.WarehouseId == warehouseId && s.IsActive == true)
            .ToListAsync();
        return models.Select(Map);
    }

    public async Task<StockEntity?> GetBySkuAndWarehouseAsync(int skuId, int warehouseId, int? batchId)
    {
        var model = await db.Stocks
            .FirstOrDefaultAsync(s => s.SkuId == skuId && s.WarehouseId == warehouseId && s.BatchId == batchId && s.IsActive == true);
        return model is null ? null : Map(model);
    }

    public async Task<StockEntity> CreateAsync(StockEntity entity)
    {
        var model = new Stock
        {
            WarehouseId = entity.WarehouseId,
            SkuId = entity.SkuId,
            BatchId = entity.BatchId,
            Quantity = entity.Quantity,
            ReservedQuantity = entity.ReservedQuantity,
            IsActive = entity.IsActive,
            LastUpdated = entity.LastUpdated
        };
        db.Stocks.Add(model);
        await db.SaveChangesAsync();
        return Map(model);
    }

    public async Task UpdateAsync(StockEntity entity)
    {
        var model = await db.Stocks.FindAsync(entity.Id);
        if (model is null) throw new KeyNotFoundException($"Stock {entity.Id} not found");
        model.Quantity = entity.Quantity;
        model.ReservedQuantity = entity.ReservedQuantity;
        model.LastUpdated = entity.LastUpdated;
        await db.SaveChangesAsync();
    }

    private static StockEntity Map(Stock m) =>
        new StockEntity().Init(m.Id, m.WarehouseId, m.SkuId, m.BatchId, m.Quantity, m.ReservedQuantity, m.IsActive ?? true, m.LastUpdated ?? DateTime.Now);
}