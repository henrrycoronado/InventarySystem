using System;
using System.Collections.Generic;
using InventarySystem.Api.src.Core.Domain;

namespace InventarySystem.Api.Modules.Sales.SubModules.PdV.Infrastructure;

public partial class PdvStationCategory
{
    public int Id { get; set; }

    public int StationId { get; set; }

    public int GlobalCategoryId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual GlobalCategory GlobalCategory { get; set; } = null!;

    public virtual PdvStation Station { get; set; } = null!;
}
