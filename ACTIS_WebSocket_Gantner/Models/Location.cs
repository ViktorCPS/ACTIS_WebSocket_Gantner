using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int ParentLocationId { get; set; }

    public string? Status { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual ICollection<Gate> Gates { get; set; } = new List<Gate>();

    public virtual ICollection<Location> InverseParentLocation { get; set; } = new List<Location>();

    public virtual Location ParentLocation { get; set; } = null!;

    public virtual ICollection<Pass> Passes { get; set; } = new List<Pass>();
}
