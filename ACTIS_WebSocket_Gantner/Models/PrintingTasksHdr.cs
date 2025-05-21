using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PrintingTasksHdr
{
    public int PrintingTaskId { get; set; }

    public string? Description { get; set; }

    public string? Remark { get; set; }

    public string? ApprovedBy { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
