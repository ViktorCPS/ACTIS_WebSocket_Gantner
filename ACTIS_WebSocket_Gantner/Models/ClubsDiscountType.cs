using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ClubsDiscountType
{
    public int DiscountTypeId { get; set; }

    public int ClubId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual ICollection<ClubsMember> ClubsMembers { get; set; } = new List<ClubsMember>();
}
