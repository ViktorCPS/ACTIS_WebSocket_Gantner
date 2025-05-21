using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class DailyInterval
{
    public int DailyIntervalId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ICollection<ResourcesBooking> ResourcesBookings { get; set; } = new List<ResourcesBooking>();

    public virtual ICollection<ResourcesTypesXDailyInterval> ResourcesTypesXDailyIntervals { get; set; } = new List<ResourcesTypesXDailyInterval>();

    public virtual ICollection<WeekSchedule> WeekSchedules { get; set; } = new List<WeekSchedule>();
}
