using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PassesArchView
{
    public string TicketId { get; set; } = null!;

    public string? ClientName { get; set; }

    public string Direction { get; set; } = null!;

    public string GateName { get; set; } = null!;

    public string TicketTypesName { get; set; } = null!;

    public DateTime EventTime { get; set; }

    public string Status { get; set; } = null!;

    public int OrdNum { get; set; }

    public string ApplUserName { get; set; } = null!;

    public int GateId { get; set; }

    public string UserId { get; set; } = null!;

    public int TicketTypeId { get; set; }

    public int ClientId { get; set; }

    public int PassId { get; set; }

    public string? LocationName { get; set; }

    public int LocationId { get; set; }

    public int Expr1 { get; set; }

    public int ValidationTerminalId { get; set; }

    public string Name { get; set; } = null!;

    public string Expr2 { get; set; } = null!;

    public int Expr3 { get; set; }
}
