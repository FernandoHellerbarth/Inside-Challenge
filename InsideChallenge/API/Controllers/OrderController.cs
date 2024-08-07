using InsideChallenge.Application.Features.Orders.Commands.AddProductsToOrder;
using InsideChallenge.Application.Features.Orders.Commands.CloseOrder;
using InsideChallenge.Application.Features.Orders.Commands.CreateOrder;
using InsideChallenge.Application.Features.Orders.Commands.RemoveProductsFromOrder;
using InsideChallenge.Application.Features.Orders.Queries.GetOrder;
using InsideChallenge.Application.Features.Orders.Queries.ListOrders;
using InsideChallenge.Application.Persistence;
using InsideChallenge.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsideChallenge.API.Controllers
{
    [Route("api/pedidos")]
    public class OrderController : APIController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var query = new GetOrderQuery() { Id = id };
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>>
            ListOrders([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10,
            [FromQuery] bool? isOrderClosed = null)
        {
            var query = new ListOrdersQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                IsOrderClosed = isOrderClosed
            };

            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrder), new { id = orderId }, null);
        }

        [HttpPut("{id}/fechar")]
        public async Task<ActionResult> CloseOrder(int id)
        {
            await _mediator.Send(new CloseOrderCommand { Id = id });
            return NoContent();
        }

        [HttpPost("{id}/adicionar-produto")]
        public async Task<IActionResult> AddProductToOrder(int id, [FromBody] AddProductsToOrderCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}/remover-produto/{productId}")]
        public async Task<IActionResult> AddProductToOrder(int id, int productId)
        {
            await _mediator.Send(new RemoveProductFromOrderCommand { Id = id, ProductId = productId });
            return NoContent();
        }
    }
}
