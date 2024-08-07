using InsideChallenge.Application.Persistence;
using MediatR;

namespace InsideChallenge.Application.Features.Orders.Queries.ListOrders
{
    public class ListOrdersQuery :IRequest<List<OrderDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool? IsOrderClosed { get; set; }

        public ListOrdersQuery(int pageNumber = 1, int pageSize = 10, bool? isOrderClosed = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            IsOrderClosed = isOrderClosed;
        }
    }
}
