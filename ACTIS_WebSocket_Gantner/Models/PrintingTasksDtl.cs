using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PrintingTasksDtl
{
    public int RecId { get; set; }

    public int PrintingTaskId { get; set; }

    public string Status { get; set; } = null!;

    public string Data1 { get; set; } = null!;

    public string Data2 { get; set; } = null!;

    public string Data3 { get; set; } = null!;

    public string Data4 { get; set; } = null!;

    public string Data5 { get; set; } = null!;

    public string Data6 { get; set; } = null!;

    public string Data7 { get; set; } = null!;

    public string Data8 { get; set; } = null!;

    public string Data9 { get; set; } = null!;

    public string Data10 { get; set; } = null!;

    public DateTime? PrintingTime { get; set; }

    public string? TicketId { get; set; }

    public int TicketTypeId { get; set; }

    public byte[] Symbol { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
