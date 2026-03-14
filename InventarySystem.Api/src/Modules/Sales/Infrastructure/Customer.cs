using System;
using System.Collections.Generic;
using InventarySystem.Api.src.Core.Domain;
using InventarySystem.Api.Modules.Sales.SubModules.PdV.Infrastructure;

namespace InventarySystem.Api.Modules.Sales.Infrastructure;

public partial class Customer
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<PdvOrder> PdvOrders { get; set; } = new List<PdvOrder>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
