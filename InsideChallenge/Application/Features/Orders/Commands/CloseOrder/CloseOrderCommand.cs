using InsideChallenge.Application.Persistence;
using MediatR;
using System.Text.Json.Serialization;

namespace InsideChallenge.Application.Features.Orders.Commands.CloseOrder
{
    public class CloseOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        [JsonIgnore]
        public List<OrderItemDto> ItemDtos { get; set; }
    }
}
