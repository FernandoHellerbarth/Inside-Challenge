using InsideChallenge.Application.Features.Orders.Commands.CloseOrder;
using InsideChallenge.Domain.Repositories;
using MediatR;

public class CloseOrderCommandHandler : IRequestHandler<CloseOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public CloseOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(CloseOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);
        order.IsOrderClosed = true;
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}