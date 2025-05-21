using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ResourcesType
{
    public int ResourceTypeId { get; set; }

    public string Name { get; set; } = null!;

    public int TicketTypeId { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

    public virtual ICollection<ResourcesBooking> ResourcesBookings { get; set; } = new List<ResourcesBooking>();

    public virtual ICollection<ResourcesTypesXDailyInterval> ResourcesTypesXDailyIntervals { get; set; } = new List<ResourcesTypesXDailyInterval>();
}
