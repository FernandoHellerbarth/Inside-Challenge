using AutoMapper;
using ErrorOr;
using InsideChallenge.Application.Persistence;
using InsideChallenge.Domain.Entities;
using InsideChallenge.Domain.Repositories;
using MediatR;

namespace InsideChallenge.Application.Features.Orders.Queries.GetOrder
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
