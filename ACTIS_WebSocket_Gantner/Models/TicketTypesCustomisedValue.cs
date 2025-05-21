using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class TicketTypesCustomisedValue
{
    public int TicketTypeId { get; set; }

    public int? IntegerValue1 { get; set; }

    public int? IntegerValue2 { get; set; }

    public int? IntegerValue3 { get; set; }

    public int? IntegerValue4 { get; set; }

    public int? IntegerValue5 { get; set; }

    public int? IntegerValue6 { get; set; }

    public int? IntegerValue7 { get; set; }

    public int? IntegerValue8 { get; set; }

    public int? IntegerValue9 { get; set; }

    public int? IntegerValue10 { get; set; }

    public DateTime? DatetimeValue1 { get; set; }

    public DateTime? DatetimeValue2 { get; set; }

    public DateTime? DatetimeValue3 { get; set; }

    public DateTime? DatetimeValue4 { get; set; }

    public DateTime? DatetimeValue5 { get; set; }

    public DateTime? DatetimeValue6 { get; set; }

    public DateTime? DatetimeValue7 { get; set; }

    public DateTime? DatetimeValue8 { get; set; }

    public DateTime? DatetimeValue9 { get; set; }

    public DateTime? DatetimeValue10 { get; set; }

    public string? NvarcharValue1 { get; set; }

    public string? NvarcharValue2 { get; set; }

    public string? NvarcharValue3 { get; set; }

    public string? NvarcharValue4 { get; set; }

    public string? NvarcharValue5 { get; set; }

    public string? NvarcharValue6 { get; set; }

    public string? NvarcharValue7 { get; set; }

    public string? NvarcharValue8 { get; set; }

    public string? NvarcharValue9 { get; set; }

    public string? NvarcharValue10 { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual TicketType TicketType { get; set; } = null!;
}
