using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ResourcesBooking
{
    public long RecId { get; set; }

    public int ResourceTypeId { get; set; }

    public int ResourceId { get; set; }

    public DateTime Date { get; set; }

    public int DailyIntervalId { get; set; }

    public int ClientId { get; set; }

    public string? Status { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual DailyInterval DailyInterval { get; set; } = null!;

    public virtual Resource Resource { get; set; } = null!;

    public virtual ResourcesType ResourceType { get; set; } = null!;

    public virtual ICollection<ResourcesBookingXTicket> ResourcesBookingXTickets { get; set; } = new List<ResourcesBookingXTicket>();
}
