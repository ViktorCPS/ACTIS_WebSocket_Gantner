using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? Data1 { get; set; }

    public string? Data2 { get; set; }

    public string? Data3 { get; set; }

    public string? Data4 { get; set; }

    public string? Data5 { get; set; }

    public string? Data6 { get; set; }

    public string? Data7 { get; set; }

    public string? Data8 { get; set; }

    public string? Data9 { get; set; }

    public string? Data10 { get; set; }

    public string? Type { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ICollection<ResourcesBooking> ResourcesBookings { get; set; } = new List<ResourcesBooking>();
}
