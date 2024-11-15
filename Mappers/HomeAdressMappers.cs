using SberBanOnline.Dtos.HomeAdress;
using SberBanOnline.Models;

namespace SberBanOnline.Mappers
{
    public static class HomeAdressMappers
    {
        public static HomeAdressDto ToHomeAdressDto(this HomeAdress homeAdress)
        {
            return new HomeAdressDto
            {
                Id = homeAdress.Id,
                Adress = homeAdress.Adress,
                Apartment = homeAdress.Apartment,
                City = homeAdress.City,
                Country = homeAdress.Country,
                Home = homeAdress.Home,
            };
        }

        public static HomeAdress ToHomeAdressFromDto(this CreateHomeAdressRequestDto createHome)
        {
            return new HomeAdress
            {
                Adress = createHome.Adress,
                Apartment = createHome.Apartment,
                City = createHome.City,
                Country = createHome.Country,
                Home = createHome.Home,
            };
        }
    }
}
