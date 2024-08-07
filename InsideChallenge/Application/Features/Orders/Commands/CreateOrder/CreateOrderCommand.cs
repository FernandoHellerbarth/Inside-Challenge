using InsideChallenge.Application.DTOs;
using MediatR;

namespace InsideChallenge.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public List<CreateOrderItemDto> Items { get; set; } = new List<CreateOrderItemDto>();
    }
}
