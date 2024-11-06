using System;
using System.Collections.Generic;

namespace SberBanOnline.Models;

public partial class ExchangeRate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}
