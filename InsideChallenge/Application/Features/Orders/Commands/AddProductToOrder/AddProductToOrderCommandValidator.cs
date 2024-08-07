using FluentValidation;
using InsideChallenge.Domain.Repositories;
using InsideChallenge.Infrastructure.Repositories;

namespace InsideChallenge.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductToOrderCommandValidator : AbstractValidator<AddProductsToOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public AddProductToOrderCommandValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(x => x.Quantity)
                    .GreaterThan(0)
                    .WithMessage("Você deve adicionar no mínimo 1 produto");

            RuleFor(x => x.Id)
                    .GreaterThan(0)
                    .WithMessage("O ID do pedido deve ser maior que 0");

            RuleFor(x => x.ProductId)
                    .GreaterThan(0)
                    .WithMessage("O ID do produto deve ser maior que 0");

            RuleFor(command => command.Id)
                .MustAsync(OrderMustNotBeClosed)
                .WithMessage("Você não pode remover produtos de um pedido fechado.");
        }
        private async Task<bool> OrderMustNotBeClosed(int id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order != null && !order.IsOrderClosed;
        }
    }
}
