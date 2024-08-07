using MediatR;
using System.Text.Json.Serialization;

namespace InsideChallenge.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductsToOrderCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
