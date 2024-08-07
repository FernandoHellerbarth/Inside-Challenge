using AutoMapper;
using InsideChallenge.Application.Persistence;
using InsideChallenge.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InsideChallenge.Application.Features.Orders.Queries.ListOrders
{
    public class ListOrdersQueryHandler : IRequestHandler<ListOrdersQuery,List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ListOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
        {
            var query = _orderRepository.GetAll();

            if (request.IsOrderClosed.HasValue)
            {
                query = query.Where(o => o.IsOrderClosed == request.IsOrderClosed.Value);
            }

            query = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            var orders = await query.ToListAsync(cancellationToken);
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
