using System;
using System.Collections.Generic;

namespace ProjectPRN212Group4.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public string VoucherCode { get; set; } = null!;

    public DateOnly? ValidUntil { get; set; }

    public DateOnly? ValidFrom { get; set; }

    public decimal? MaxDiscountAmount { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
