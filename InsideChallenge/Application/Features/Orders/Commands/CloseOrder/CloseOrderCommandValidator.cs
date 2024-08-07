using FluentValidation;
using InsideChallenge.Domain.Repositories;

namespace InsideChallenge.Application.Features.Orders.Commands.CloseOrder
{
    public class CloseOrderCommandValidator : AbstractValidator<CloseOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CloseOrderCommandValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(x => x.Id)
                .MustAsync(HaveAtLeastOneItem)
                .WithMessage("O pedido deve ter no mínimo 1 item para poder ser fechado");
        }

        private async Task<bool> HaveAtLeastOneItem(int orderId, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            return order != null && order.Items.Any();
        }
    }
}
