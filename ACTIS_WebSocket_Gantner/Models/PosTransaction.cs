using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PosTransaction
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

    public virtual ICollection<PosDailyReportsXPosTransaction> PosDailyReportsXPosTransactions { get; set; } = new List<PosDailyReportsXPosTransaction>();

    public virtual ICollection<PosTransactionLine> PosTransactionLines { get; set; } = new List<PosTransactionLine>();

    public virtual PosTransactionPaymentMthd? PosTransactionPaymentMthd { get; set; }

    public virtual ApplUser User { get; set; } = null!;
}
