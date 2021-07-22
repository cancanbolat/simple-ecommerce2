using E_Commerce.Application.Features.Commands.Cart;
using E_Commerce.Application.Features.Queries.Cart;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator mediator;

        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCardItems(string userId)
        {
            var query = new GetAllCartItemQuery() { UserId = userId };
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> AddCard(AddCartCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost("{id}/{quantityActionType}")]
        public async Task<IActionResult> UpdateCard(int id, int quantityActionType)
        {
            var command = new UpdateCartCommand() { Id = id, QuantityActionType = quantityActionType };
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var command = new DeleteCartCommand() { Id = id };
            return Ok(await mediator.Send(command));
        }
    }
}
