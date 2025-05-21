using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class Club
{
    public int ClubId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ICollection<ClubsDiscountType> ClubsDiscountTypes { get; set; } = new List<ClubsDiscountType>();

    public virtual ICollection<ClubsGroup> ClubsGroups { get; set; } = new List<ClubsGroup>();

    public virtual ICollection<ClubsMember> ClubsMembers { get; set; } = new List<ClubsMember>();

    public virtual ICollection<ClubsXClubsCoach> ClubsXClubsCoaches { get; set; } = new List<ClubsXClubsCoach>();
}
