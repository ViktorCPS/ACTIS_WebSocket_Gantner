using System;
using System.Collections.Generic;

namespace ACTIS_WebSocket_Gantner.Models;

public partial class PosTransactionPaymentMthdArch
{
    public long TransactionId { get; set; }

    public decimal? AmountMthd1 { get; set; }

    public decimal? AmountMthd2 { get; set; }

    public decimal? AmountMthd3 { get; set; }

    public decimal? AmountMthd4 { get; set; }

    public decimal? AmountMthd5 { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedTime { get; set; }
}
