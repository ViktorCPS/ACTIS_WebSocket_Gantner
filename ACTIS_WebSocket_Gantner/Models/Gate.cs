using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class Gate
{
    public int GateId { get; set; }

    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Pass> Passes { get; set; } = new List<Pass>();

    public virtual ICollection<ValidationTerminal> ValidationTerminals { get; set; } = new List<ValidationTerminal>();

    public virtual ICollection<WeekSchedulesXGate> WeekSchedulesXGates { get; set; } = new List<WeekSchedulesXGate>();
}
