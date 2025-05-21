using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class Resource
{
    public int ResourceTypeId { get; set; }

    public int ResourceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ResourcesType ResourceType { get; set; } = null!;

    public virtual ICollection<ResourcesBooking> ResourcesBookings { get; set; } = new List<ResourcesBooking>();
}
