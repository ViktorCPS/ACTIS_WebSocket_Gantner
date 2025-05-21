using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PosTransactionArch
{
    public long TransactionId { get; set; }

    public decimal Amount { get; set; }

    public decimal AmountReceived { get; set; }

    public string UserId { get; set; } = null!;

    public int PosId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Po Pos { get; set; } = null!;

    public virtual ICollection<PosDailyReportsArchXPosTransactionArch> PosDailyReportsArchXPosTransactionArches { get; set; } = new List<PosDailyReportsArchXPosTransactionArch>();

    public virtual ICollection<PosTransactionLinesArch> PosTransactionLinesArches { get; set; } = new List<PosTransactionLinesArch>();

    public virtual ApplUser User { get; set; } = null!;
}
