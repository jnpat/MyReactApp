using System;
using System.Collections.Generic;

namespace MyReactApp.Server.Models;

public partial class Price
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public string? Currency { get; set; }

    public decimal Amount { get; set; }

    public string? OgCurrency { get; set; }

    public decimal OgAmount { get; set; }

    public string? FpCurrency { get; set; }

    public decimal FpAmount { get; set; }

    public string? DpCurrency { get; set; }

    public decimal DpAmount { get; set; }

    public virtual Product Product { get; set; } = null!;
}
