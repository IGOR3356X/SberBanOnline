using Microsoft.AspNetCore.Mvc;
using SberBanOnline.Dtos.Card;
using SberBanOnline.Dtos.GG;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Controllers
{
    [ApiController]
    [Route("api/Card/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardServices _cardServices;

        public CardController(ICardServices cardServices)
        {
            _cardServices = cardServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var CardList = await _cardServices.GetAllAsync();

            return Ok(CardList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById(int id)
        {
            var selectedCard = await _cardServices.GetCardByIdAsync(id);

            if (selectedCard != null)
            {
                return Ok(selectedCard);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(CreateCardRequestDto cardModel)
        {
            var createdCard = await _cardServices.CreateCard(cardModel);

            return Ok(createdCard);
        }

        [HttpPut]
        [Route ("{id}")]
        public async Task<IActionResult> UpdateCard([FromRoute]int id, [FromBody] UpdateCardRequestDto updateDto)
        {
            var updatedCard  = await _cardServices.UpdateCard(updateDto,id);

            if (updatedCard == null)
            {
                return NotFound();
            }

            return Ok(updatedCard);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCard([FromRoute]int id)
        {
            var isDeleted = await _cardServices.DeleteCard(id);

            if(isDeleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
