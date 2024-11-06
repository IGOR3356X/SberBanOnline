using System;
using System.Collections.Generic;

namespace SberBanOnline.Models;

public partial class TransactionType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
