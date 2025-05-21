using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ValidationTerminalsSetting
{
    public int ValidationTerminalId { get; set; }

    public int ReaderPingPeriod { get; set; }

    public string? CameraIp1 { get; set; }

    public string? CameraIp2 { get; set; }

    public string? CameraIp3 { get; set; }

    public string? CameraIp4 { get; set; }

    public int? VirtualValidationTerminalId { get; set; }

    public int PassTimeOut { get; set; }

    public int TicketTransactionTimeout { get; set; }

    public int BlockPassInterval { get; set; }

    public int LogDebugMessages { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int PrinterUsed { get; set; }

    public string? PrinterType { get; set; }

    public virtual ValidationTerminal ValidationTerminal { get; set; } = null!;

    public virtual ValidationTerminal? VirtualValidationTerminal { get; set; }
}
