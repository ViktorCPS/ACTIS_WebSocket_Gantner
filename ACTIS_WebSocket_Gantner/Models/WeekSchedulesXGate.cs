using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class WeekSchedulesXGate
{
    public int WeekScheduleId { get; set; }

    public int Day { get; set; }

    public int DailyIntervalId { get; set; }

    public int GateId { get; set; }

    public string? Purpose { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Gate Gate { get; set; } = null!;

    public virtual WeekSchedule WeekSchedule { get; set; } = null!;
}
