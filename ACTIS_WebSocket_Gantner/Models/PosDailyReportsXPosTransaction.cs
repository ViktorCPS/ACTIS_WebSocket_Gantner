using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PosDailyReportsXPosTransaction
{
    public long ReportId { get; set; }

    public long TransactionId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual PosDailyReport Report { get; set; } = null!;

    public virtual PosTransaction Transaction { get; set; } = null!;
}
