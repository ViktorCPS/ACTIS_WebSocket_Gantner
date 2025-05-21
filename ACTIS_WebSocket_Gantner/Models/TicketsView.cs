using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class TicketsView
{
    public string TicketId { get; set; } = null!;

    public int OrdNum { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public string IssuedBy { get; set; } = null!;

    public DateTime TimeIssued { get; set; }

    public int LimitTotal { get; set; }

    public string Status { get; set; } = null!;

    public int TicketTypeId { get; set; }

    public int? EventId { get; set; }

    public int? PosId { get; set; }

    public int? ClientId { get; set; }

    public string? Data2 { get; set; }

    public string? Data3 { get; set; }

    public string? Data4 { get; set; }

    public string? Data5 { get; set; }

    public string? Data6 { get; set; }

    public string? Data7 { get; set; }

    public string? Data8 { get; set; }

    public string? Data9 { get; set; }

    public string? Data10 { get; set; }

    public string? Type { get; set; }

    public string? Data1 { get; set; }

    public string SoldBy { get; set; } = null!;

    public DateTime TimeSold { get; set; }

    public string TicketTypeName { get; set; } = null!;

    public string? AuthorisedTo { get; set; }

    public string? ApprovedBy { get; set; }

    public decimal? Price { get; set; }

    public string? OrigTicketId { get; set; }
}
