using System;
using System.Collections.Generic;

namespace ProjectPRN212Group4.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal FinalAmount { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? VoucherId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Voucher? Voucher { get; set; }
}
