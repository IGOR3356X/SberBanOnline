using System;
using System.Collections.Generic;

namespace SberBanOnline.Models;

public partial class HomeAdress
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Home { get; set; } = null!;

    public int Apartment { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
