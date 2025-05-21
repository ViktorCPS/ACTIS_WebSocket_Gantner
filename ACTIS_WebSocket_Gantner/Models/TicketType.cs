using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class TicketType
{
    public int TicketTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public string ScheduleType { get; set; } = null!;

    public string IssuingMethod { get; set; } = null!;

    public string IssuingTechnology { get; set; } = null!;

    public int Personalised { get; set; }

    public string TypeGroups { get; set; } = null!;

    public string TypeObject { get; set; } = null!;

    public string TypeRegularity { get; set; } = null!;

    public string LimitRule { get; set; } = null!;

    public int? LimitRuleValue { get; set; }

    public int? LimitRuleValueMin { get; set; }

    public int? LimitRuleValueMax { get; set; }

    public int WeekScheduleId { get; set; }

    public string ValidityRuleStart { get; set; } = null!;

    public int? ValidityRuleStartValue { get; set; }

    public string MultipleIssuingRule { get; set; } = null!;

    public string ValidityRuleDuration { get; set; } = null!;

    public int? ValidityRuleDurationValue { get; set; }

    public int? ValidityRuleDurationValueOffset { get; set; }

    public string? ValidityRuleCustomised { get; set; }

    public string? ValidityRuleTailing { get; set; }

    public int? ValidityRuleTailingValue { get; set; }

    public int TailingAllowed { get; set; }

    public int? LimitTail { get; set; }

    public decimal? Price { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? ValidityRuleTailingIntervalValue { get; set; }

    public int? ArticleId { get; set; }

    public string? MasterTicketId { get; set; }

    public int? ValidityRuleMasterValue { get; set; }

    public int PayPerHrsRule { get; set; }

    public virtual ICollection<PosTransactionLine> PosTransactionLines { get; set; } = new List<PosTransactionLine>();

    public virtual ICollection<PosTransactionLinesArch> PosTransactionLinesArches { get; set; } = new List<PosTransactionLinesArch>();

    public virtual TicketTypesCustomisedValue? TicketTypesCustomisedValue { get; set; }

    public virtual ICollection<TicketTypesInterface> TicketTypesInterfaces { get; set; } = new List<TicketTypesInterface>();

    public virtual ICollection<TicketTypesXEvent> TicketTypesXEvents { get; set; } = new List<TicketTypesXEvent>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<TicketsArch> TicketsArches { get; set; } = new List<TicketsArch>();

    public virtual ICollection<TicketsHistArch> TicketsHistArches { get; set; } = new List<TicketsHistArch>();

    public virtual ICollection<TicketsHist> TicketsHists { get; set; } = new List<TicketsHist>();
}
