using System.Text.Json.Serialization;

namespace InsideChallenge.Application.Persistence
{
    public class OrderItemDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
