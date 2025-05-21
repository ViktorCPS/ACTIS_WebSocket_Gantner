using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class TicketTypesXEvent
{
    public int TicketTypeId { get; set; }

    public int EventId { get; set; }

    public int SecNum { get; set; }

    public string? Purpose { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual TicketType TicketType { get; set; } = null!;
}
