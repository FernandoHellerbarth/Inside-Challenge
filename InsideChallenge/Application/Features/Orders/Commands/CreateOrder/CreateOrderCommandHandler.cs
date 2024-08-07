using AutoMapper;
using InsideChallenge.Application.Features.Orders.Commands.CreateOrder;
using InsideChallenge.Domain.Entities;
using InsideChallenge.Domain.Repositories;
using MediatR;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Create the order entity
        var order = new Order
        {
            IsOrderClosed = false,
            CreatedAt = DateTimeOffset.UtcNow,
            Items = new List<OrderItem>()
        };

        // Add order items
        foreach (var itemDto in request.Items)
        {
            var product = await _productRepository.GetByIdAsync(itemDto.ProductId);
            if (product != null)
            {
                var orderItem = new OrderItem
                {
                    Product = product,
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    Order = order,
                    OrderId = order.Id
                };

                order.Items.Add(orderItem);
            }
        }

        await _orderRepository.CreateAsync(order);

        return order.Id; // Return the created order's ID
    }
}