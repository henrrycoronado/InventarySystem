using System;
using System.Collections.Generic;
using InventarySystem.Api.src.Core.Domain;

namespace InventarySystem.Api.Modules.Inventory.Infrastructure;

public partial class CompanyAttribute
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<SkuAttributeValue> SkuAttributeValues { get; set; } = new List<SkuAttributeValue>();
}
