using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class EventsView
{
    public int EventId { get; set; }

    public string Name { get; set; } = null!;

    public string? Status { get; set; }

    public string? Description { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public DateTime TicketSaleStart { get; set; }

    public DateTime TicketSaleEnd { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
