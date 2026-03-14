namespace InventarySystem.Api.Modules.Inventory.Domain.Entities;

public class KardexEntity
{
    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public int WarehouseId { get; private set; }
    public int SkuId { get; private set; }
    public int? BatchId { get; private set; }
    public int MovementDetailId { get; private set; }
    public int TypeId { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal BalanceAfter { get; private set; }
    public DateTime CreatedAt { get; private set; }

    internal KardexEntity() { }

    public static KardexEntity Create(int companyId, int warehouseId, int skuId, int? batchId, int movementDetailId, int typeId, decimal quantity, decimal balanceAfter) =>
        new() { CompanyId = companyId, WarehouseId = warehouseId, SkuId = skuId, BatchId = batchId, MovementDetailId = movementDetailId, TypeId = typeId, Quantity = quantity, BalanceAfter = balanceAfter, CreatedAt = DateTime.Now };

    internal KardexEntity Init(int id, int companyId, int warehouseId, int skuId, int? batchId, int movementDetailId, int typeId, decimal quantity, decimal balanceAfter, DateTime createdAt)
    {
        Id = id; CompanyId = companyId; WarehouseId = warehouseId; SkuId = skuId;
        BatchId = batchId; MovementDetailId = movementDetailId; TypeId = typeId;
        Quantity = quantity; BalanceAfter = balanceAfter; CreatedAt = createdAt;
        return this;
    }
}