using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class TagsEvidentionTransaction
{
    public long TransactionId { get; set; }

    public int Total { get; set; }

    public string? UserId { get; set; }

    public string? Type { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
