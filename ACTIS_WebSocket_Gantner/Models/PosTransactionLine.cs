using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PosTransactionLine
{
    public long TransactionId { get; set; }

    public int LineNum { get; set; }

    public int? EventId { get; set; }

    public int TicketTypeId { get; set; }

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public decimal Amount { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? PeopleNum { get; set; }

    public virtual ICollection<PosTransactionLinesDtl> PosTransactionLinesDtls { get; set; } = new List<PosTransactionLinesDtl>();

    public virtual TicketType TicketType { get; set; } = null!;

    public virtual PosTransaction Transaction { get; set; } = null!;
}
