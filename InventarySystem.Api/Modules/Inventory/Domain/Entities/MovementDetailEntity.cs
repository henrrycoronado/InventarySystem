namespace InventarySystem.Api.Modules.Inventory.Domain.Entities;

public class MovementDetailEntity
{
    public int Id { get; private set; }
    public int MovementId { get; private set; }
    public int SkuId { get; private set; }
    public int? BatchId { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal? UnitCost { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal MovementDetailEntity() { }

    public static MovementDetailEntity Create(int movementId, int skuId, int? batchId, decimal quantity, decimal? unitCost) =>
        new() { MovementId = movementId, SkuId = skuId, BatchId = batchId, Quantity = quantity, UnitCost = unitCost, IsActive = true, CreatedAt = DateTime.Now };

    internal MovementDetailEntity Init(int id, int movementId, int skuId, int? batchId, decimal quantity, decimal? unitCost, bool isActive, DateTime createdAt)
    {
        Id = id; MovementId = movementId; SkuId = skuId; BatchId = batchId;
        Quantity = quantity; UnitCost = unitCost; IsActive = isActive; CreatedAt = createdAt;
        return this;
    }
}