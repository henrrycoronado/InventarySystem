using System;
using System.Collections.Generic;
using InventarySystem.Api.src.Core.Domain;

namespace InventarySystem.Api.Modules.Inventory.Infrastructure;

public partial class Kardex
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int WarehouseId { get; set; }

    public int SkuId { get; set; }

    public int? BatchId { get; set; }

    public int MovementDetailId { get; set; }

    public int TypeId { get; set; }

    public decimal Quantity { get; set; }

    public decimal BalanceAfter { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Batch? Batch { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual MovementDetail MovementDetail { get; set; } = null!;

    public virtual CompanySku Sku { get; set; } = null!;

    public virtual MovementType Type { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
