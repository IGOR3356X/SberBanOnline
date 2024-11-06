using Microsoft.AspNetCore.Mvc;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;
using SberBanOnline.Services;

namespace SberBanOnline.Controllers
{
    [ApiController]
    [Route("api/ExchangeRate/[controller]")]
    public class ExchangeRateController: ControllerBase
    {
        private readonly IExchangeRateServices _exchangeRateServices;

        public ExchangeRateController(IExchangeRateServices exchangeRateServices)
        {
            _exchangeRateServices  = exchangeRateServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cardTypeList = await _exchangeRateServices.GetAllAsync();
            return Ok(cardTypeList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ExchangeRateById(int id)
        {
            var getId = await _exchangeRateServices.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExchangeRate(ExchangeRate exchangeRate)
        {
            var createResult = await _exchangeRateServices.CreateCardTypeAsync(exchangeRate);

            return CreatedAtAction(nameof(CreateExchangeRate), new { exchangeRate });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteExchangeRate([FromRoute] int id)
        {
            var deletedResult = await _exchangeRateServices.DeleteCardTypeAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateExchangeRate(int id, ExchangeRate exchangeRate)
        {
            var updatedCardType = await _exchangeRateServices.UpdateCardTypeAsync(id, exchangeRate);

            if (updatedCardType == null)
            {
                return NotFound();
            }

            return Ok(updatedCardType);
        }
    }
}
