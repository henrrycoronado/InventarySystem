using System;
using System.Collections.Generic;

namespace InventarySystem.Api.Modules.Sales.SubModules.PdV.Infrastructure;

public partial class PdvItemStatus
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<PdvOrderDetail> PdvOrderDetails { get; set; } = new List<PdvOrderDetail>();
}
