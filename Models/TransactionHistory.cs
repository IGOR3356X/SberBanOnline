using System;
using System.Collections.Generic;

namespace SberBanOnline.Models;

public partial class TransactionHistory
{
    public int Id { get; set; }

    public int SendCardId { get; set; }

    public int RecipientCardId { get; set; }

    public decimal SunOfMoney { get; set; }

    public DateTime DatetimeDearture { get; set; }

    public int TransactionId { get; set; }

    public virtual Card RecipientCard { get; set; } = null!;

    public virtual Card SendCard { get; set; } = null!;

    public virtual TransactionType Transaction { get; set; } = null!;
}
