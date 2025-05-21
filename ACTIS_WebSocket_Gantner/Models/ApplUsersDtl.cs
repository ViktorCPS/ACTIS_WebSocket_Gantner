using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ApplUsersDtl
{
    public int RecId { get; set; }

    public string UserId { get; set; } = null!;

    public string Purpose { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ApplUser User { get; set; } = null!;
}
