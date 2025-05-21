using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ClubsXClubsCoach
{
    public int CoachId { get; set; }

    public int ClubId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual ClubsCoach Coach { get; set; } = null!;
}
