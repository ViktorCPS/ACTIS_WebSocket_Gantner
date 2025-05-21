using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PosTransactionLinesDtlArch
{
    public long TransactionId { get; set; }

    public int LineNum { get; set; }

    public string TicketId { get; set; } = null!;

    public int OrdNum { get; set; }

    public string? PrintOrd { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual PosTransactionLinesArch PosTransactionLinesArch { get; set; } = null!;
}
