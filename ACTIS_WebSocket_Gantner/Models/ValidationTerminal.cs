using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ValidationTerminal
{
    public int ValidationTerminalId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int Virtual { get; set; }

    public string? Remark { get; set; }

    public string IpAddress { get; set; } = null!;

    public string? Direction { get; set; }

    public int GateId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? DropArm { get; set; }

    public virtual Gate Gate { get; set; } = null!;

    public virtual ICollection<Pass> Passes { get; set; } = new List<Pass>();

    public virtual ValidationTerminalsSetting? ValidationTerminalsSettingValidationTerminal { get; set; }

    public virtual ICollection<ValidationTerminalsSetting> ValidationTerminalsSettingVirtualValidationTerminals { get; set; } = new List<ValidationTerminalsSetting>();
}
