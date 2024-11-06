using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SberBankOnline.Interfaces.Repository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBankOnline.Controllers
{
    [ApiController]
    [Route("api/CardType/[controller]")]
    public class CardTypeConroller:ControllerBase
    {
        private readonly ICardTypeServices _cardTypeServices;
        public CardTypeConroller(ICardTypeServices cardServices)
        {
            _cardTypeServices = cardServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cardTypeList = await _cardTypeServices.GetAllAsync();
            return Ok(cardTypeList);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetCardTypeById(int id)
        {
            var getId = await _cardTypeServices.GetByIdAsync(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardType(CardType cardType)
        {
            var createResult = await _cardTypeServices.CreateCardTypeAsync(cardType);

            return CreatedAtAction(nameof(CreateCardType), new {cardType} );
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCardType([FromRoute] int id)
        {
            var deletedResult = await _cardTypeServices.DeleteCardTypeAsync(id);

            if (deletedResult == false)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCardType([FromRoute]int id ,CardType cardType)
        {
            var updatedCardType = await _cardTypeServices.UpdateCardTypeAsync(id,cardType);
            
            if (updatedCardType == null)
            {
                return NotFound();
            }

            return Ok(updatedCardType);
        }
    }
}
