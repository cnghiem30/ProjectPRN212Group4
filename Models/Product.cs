using System;
using System.Collections.Generic;

namespace ProjectPRN212Group4.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? SizeName { get; set; }

    public string? ColorName { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int? TypeId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual TypeProduct? Type { get; set; }
}
