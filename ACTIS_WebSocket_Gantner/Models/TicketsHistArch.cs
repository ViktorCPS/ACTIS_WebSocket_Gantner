using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class TicketsHistArch
{
    public long RecId { get; set; }

    public string TicketId { get; set; } = null!;

    public int OrdNum { get; set; }

    public int TicketTypeId { get; set; }

    public int? EventId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime TimeIssued { get; set; }

    public string IssuedBy { get; set; } = null!;

    public DateTime TimeSold { get; set; }

    public string SoldBy { get; set; } = null!;

    public int? PosId { get; set; }

    public int? ClientId { get; set; }

    public string? AuthorisedTo { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public int LimitTotal { get; set; }

    public string? OrigTicketId { get; set; }

    public int? OrigOrdNum { get; set; }

    public string? ApprovedBy { get; set; }

    public decimal? Price { get; set; }

    public string? Remark { get; set; }

    public int? PeopleNum { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Po? Pos { get; set; }

    public virtual TicketType TicketType { get; set; } = null!;
}
