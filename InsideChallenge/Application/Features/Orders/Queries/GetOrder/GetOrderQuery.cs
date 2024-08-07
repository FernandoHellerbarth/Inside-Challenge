using InsideChallenge.Application.Persistence;
using MediatR;

namespace InsideChallenge.Application.Features.Orders.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public int Id {  get; set; }
    }
}
