using System;
using System.Collections.Generic;
using InventarySystem.Api.Modules.Inventory.Infrastructure;

namespace InventarySystem.Api.src.Core.Domain;

public partial class GlobalProduct
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Brand { get; set; }

    public string? UpcBarcode { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual GlobalCategory? Category { get; set; }

    public virtual ICollection<CompanyProduct> CompanyProducts { get; set; } = new List<CompanyProduct>();
}
