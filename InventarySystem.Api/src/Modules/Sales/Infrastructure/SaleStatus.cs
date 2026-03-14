using System;
using System.Collections.Generic;

namespace InventarySystem.Api.Modules.Sales.Infrastructure;

public partial class SaleStatus
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
