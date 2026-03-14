using System;
using System.Collections.Generic;
using InventarySystem.Api.Modules.Inventory.Infrastructure;

namespace InventarySystem.Api.Modules.Sales.Infrastructure;

public partial class SaleDetail
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int SkuId { get; set; }

    public int? BatchId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Batch? Batch { get; set; }

    public virtual Sale Sale { get; set; } = null!;

    public virtual CompanySku Sku { get; set; } = null!;
}
