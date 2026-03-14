using System;
using System.Collections.Generic;

namespace InventarySystem.Api.Modules.Sales.Infrastructure;

public partial class Receipt
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? IssuedAt { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Sale Sale { get; set; } = null!;
}
