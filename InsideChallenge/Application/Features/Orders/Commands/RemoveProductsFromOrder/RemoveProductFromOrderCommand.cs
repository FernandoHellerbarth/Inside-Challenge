using MediatR;

namespace InsideChallenge.Application.Features.Orders.Commands.RemoveProductsFromOrder
{
    public class RemoveProductFromOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
    }
}
