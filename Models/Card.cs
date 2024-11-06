using System;
using System.Collections.Generic;

namespace SberBanOnline.Models;

public partial class Card
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public int Cvv { get; set; }

    public long Balance { get; set; }

    public int CardTypeId { get; set; }

    public int UserId { get; set; }

    public virtual CardType CardType { get; set; } = null!;

    public virtual ICollection<TransactionHistory> TransactionHistoryRecipientCards { get; set; } = new List<TransactionHistory>();

    public virtual ICollection<TransactionHistory> TransactionHistorySendCards { get; set; } = new List<TransactionHistory>();

    public virtual User User { get; set; } = null!;
}
