using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class Log
{
    public long LogId { get; set; }

    public string MethodName { get; set; } = null!;

    public string Arguments { get; set; } = null!;

    public int Result { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string Host { get; set; } = null!;

    public DateTime EventTime { get; set; }

    public string? Exception { get; set; }
}
