using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ApplMenuItem
{
    public string ApplMenuItemId { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int PrivilegeLvl { get; set; }

    public string Position { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
