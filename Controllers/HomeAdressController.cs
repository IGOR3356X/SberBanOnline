using Microsoft.AspNetCore.Mvc;
using SberBanOnline.Dtos.HomeAdress;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeAdressController:ControllerBase
    {
        private readonly IHomeAdressServices _services;
        public HomeAdressController(IHomeAdressServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var listAdress = await _services.GetAllAsync();
            return Ok(listAdress);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdressByIdAsync(int id)
        {
            var selectedAdress = await _services.GetByIdAsync(id);

            if (selectedAdress == null)
            {
                return NotFound();
            }

            return Ok(selectedAdress);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdressAsync([FromBody] CreateHomeAdressRequestDto createAdress)
        {
            var createdAdress = await _services.CreateAdressAsync(createAdress);

            return Ok(createdAdress);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAdressAsync([FromBody] UpdateHomeAdressRequestDto updateDto,[FromRoute]int id)
        {
            var selectedAdress =  await _services.UpdateAdressAsync(id,updateDto);

            if (selectedAdress == null)
            {
                return NotFound();
            }

            return Ok (selectedAdress);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAdressAsync(int id)
        {
            var selectedAdress = await _services.GetByIdAsync(id);

            if(selectedAdress == null)
            {
                return NotFound();
            }

            await _services.DeleteAdressAsync(id);
            return NoContent();
        }
    }
}
