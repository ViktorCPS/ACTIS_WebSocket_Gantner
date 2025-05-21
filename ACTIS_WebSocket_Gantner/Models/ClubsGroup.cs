using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ClubsGroup
{
    public int GroupId { get; set; }

    public int ClubId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? CoachId { get; set; }

    public int? TicketTypeId { get; set; }

    public string ValidationRule { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual ICollection<ClubsMember> ClubsMembers { get; set; } = new List<ClubsMember>();

    public virtual ClubsCoach? Coach { get; set; }
}
