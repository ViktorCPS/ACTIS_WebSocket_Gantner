using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PosTransactionLinesArch
{
    public long TransactionId { get; set; }

    public int LineNum { get; set; }

    public int? EventId { get; set; }

    public int TicketTypeId { get; set; }

    public int Qty { get; set; }

    public int? PeopleNum { get; set; }

    public decimal Price { get; set; }

    public decimal Amount { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ICollection<PosTransactionLinesDtlArch> PosTransactionLinesDtlArches { get; set; } = new List<PosTransactionLinesDtlArch>();

    public virtual TicketType TicketType { get; set; } = null!;

    public virtual PosTransactionArch Transaction { get; set; } = null!;
}
