﻿namespace SberBanOnline.Dtos.HomeAdress
{
    public class HomeAdressDto
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string Home { get; set; } = null!;
        public int Apartment { get; set; }
    }
}