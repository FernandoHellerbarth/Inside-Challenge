using InsideChallenge.Domain.Entities;
using InsideChallenge.Domain.Repositories;
using MediatR;

namespace InsideChallenge.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductToOrderCommandHandler : IRequestHandler<AddProductsToOrderCommand,Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public AddProductToOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(AddProductsToOrderCommand request, CancellationToken cancellationToken)
        {
            if(request.Quantity < 1)
            {
                throw new Exception();
            }

            var order = await _orderRepository.GetByIdAsync(request.Id);
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            var existingOrderItem = order.Items.FirstOrDefault(item => item.ProductId == request.ProductId);

            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity += request.Quantity;
            }
            else
            {
                var orderItem = new OrderItem
                {
                    OrderId = request.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };

                order.Items.Add(orderItem);
            }

            await _orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
