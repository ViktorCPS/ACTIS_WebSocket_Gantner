using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ResourcesTypesXDailyInterval
{
    public int ResourceTypeId { get; set; }

    public int DailyIntervalId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual DailyInterval DailyInterval { get; set; } = null!;

    public virtual ResourcesType ResourceType { get; set; } = null!;
}
