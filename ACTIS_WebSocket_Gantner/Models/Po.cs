using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class Po
{
    public int PosId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string TagId { get; set; } = null!;

    public int? ComMonitor { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ICollection<PosDailyReport> PosDailyReports { get; set; } = new List<PosDailyReport>();

    public virtual ICollection<PosDailyReportsArch> PosDailyReportsArches { get; set; } = new List<PosDailyReportsArch>();

    public virtual ICollection<PosTransactionArch> PosTransactionArches { get; set; } = new List<PosTransactionArch>();

    public virtual ICollection<PosTransaction> PosTransactions { get; set; } = new List<PosTransaction>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<TicketsArch> TicketsArches { get; set; } = new List<TicketsArch>();

    public virtual ICollection<TicketsHistArch> TicketsHistArches { get; set; } = new List<TicketsHistArch>();

    public virtual ICollection<TicketsHist> TicketsHists { get; set; } = new List<TicketsHist>();
}
