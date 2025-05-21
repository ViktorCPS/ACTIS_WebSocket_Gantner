using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class ClubsMembersHist
{
    public int RecD { get; set; }

    public int ClubMemberId { get; set; }

    public int ClubId { get; set; }

    public int GroupId { get; set; }

    public string Status { get; set; } = null!;

    public int DiscountTypeId { get; set; }

    public string TicketId { get; set; } = null!;

    public int? CoachId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PersonalNum { get; set; }

    public string? PlaceBirth { get; set; }

    public string? Adress { get; set; }

    public string? TelHome { get; set; }

    public string? TelMob { get; set; }

    public string? Citizenship { get; set; }

    public string? PassportNum { get; set; }

    public string? RegNum { get; set; }

    public int ClientId { get; set; }

    public string? Remark { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
