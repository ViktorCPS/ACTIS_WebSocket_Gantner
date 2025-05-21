using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class EventsAdditionalDatum
{
    public int RecId { get; set; }

    public int EventId { get; set; }

    public string XmlTemplate { get; set; } = null!;

    public byte[]? LogoDisplay1 { get; set; }

    public byte[]? LogoDisplay2 { get; set; }

    public byte[]? LogoDisplay3 { get; set; }

    public byte[]? LogoAdditional1 { get; set; }

    public byte[]? LogoAdditional2 { get; set; }

    public byte[]? LogoAdditional3 { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public virtual Event Event { get; set; } = null!;
}
