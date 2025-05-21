using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ApplUsersLog
{
    public long LoginId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime LoginTime { get; set; }

    public string Host { get; set; } = null!;

    public DateTime? LogoutTime { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
