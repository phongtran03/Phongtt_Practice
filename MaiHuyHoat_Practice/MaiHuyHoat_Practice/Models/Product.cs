using System;
using System.Collections.Generic;

namespace MaiHuyHoat_Practice.Models;

public partial class Product
{
    public long Id { get; set; }

    public string? Name { get; set; } = "";

    public DateTime? ExpDate { get; set; }

    public int Status { get; set; }

    public decimal Price { get; set; } = 0;

    public int Amount { get; set; } = 0;

    public string? Description { get; set; } = "";

    public DateTime CreatedDate { get; set; }

    public string? CreatedBy { get; set; } = null!;

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
