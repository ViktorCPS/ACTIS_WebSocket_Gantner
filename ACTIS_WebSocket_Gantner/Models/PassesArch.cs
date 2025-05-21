using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PassesArch
{
    public int PassId { get; set; }

    public string TicketId { get; set; } = null!;

    public int OrdNum { get; set; }

    public DateTime EventTime { get; set; }

    public int ValidationTerminalId { get; set; }

    public int LocationId { get; set; }

    public int GateId { get; set; }

    public string Direction { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
