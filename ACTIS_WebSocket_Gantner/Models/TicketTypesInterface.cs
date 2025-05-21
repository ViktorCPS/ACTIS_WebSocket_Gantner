using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class TicketTypesInterface
{
    public int RecId { get; set; }

    public int TicketTypeId { get; set; }

    public int TicketTypeInterfaceId { get; set; }

    public string Name { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual TicketType TicketType { get; set; } = null!;
}
