using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ApplUser
{
    public string UserId { get; set; } = null!;

    public string? Password { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int PrivilegeLvl { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? ApplUsersTypeId { get; set; }

    public virtual ICollection<ApplUsersDtl> ApplUsersDtls { get; set; } = new List<ApplUsersDtl>();

    public virtual ICollection<PosDailyReport> PosDailyReports { get; set; } = new List<PosDailyReport>();

    public virtual ICollection<PosDailyReportsArch> PosDailyReportsArches { get; set; } = new List<PosDailyReportsArch>();

    public virtual ICollection<PosTransactionArch> PosTransactionArches { get; set; } = new List<PosTransactionArch>();

    public virtual ICollection<PosTransaction> PosTransactions { get; set; } = new List<PosTransaction>();
}
