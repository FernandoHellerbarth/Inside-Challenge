using InsideChallenge.Domain.Repositories;
using MediatR;

namespace InsideChallenge.Application.Features.Orders.Commands.RemoveProductsFromOrder
{
    public class RemoveProductFromOrderCommandHandler : IRequestHandler<RemoveProductFromOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveProductFromOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(RemoveProductFromOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            var orderItem = order.Items.FirstOrDefault(i => i.ProductId == request.ProductId);

            order.Items.Remove(orderItem);
            await _orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
