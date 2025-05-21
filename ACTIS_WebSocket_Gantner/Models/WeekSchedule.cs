using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class WeekSchedule
{
    public int WeekScheduleId { get; set; }

    public int Day { get; set; }

    public int DailyIntervalId { get; set; }

    public int? LimitDay { get; set; }

    public int? LimitInterval { get; set; }

    public string ValidityRuleMultipleUssing { get; set; } = null!;

    public int? ValidityRuleMultipleUssingValue { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? ValidityRuleMultipleUssingValueExit { get; set; }

    public virtual DailyInterval DailyInterval { get; set; } = null!;

    public virtual ICollection<WeekSchedulesXGate> WeekSchedulesXGates { get; set; } = new List<WeekSchedulesXGate>();
}
