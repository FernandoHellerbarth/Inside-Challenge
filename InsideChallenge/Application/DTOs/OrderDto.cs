namespace InsideChallenge.Application.Persistence
{
    public class OrderDto
    {
        public int Id { get; set; }
        public bool IsOrderClosed { get; set; }
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
        public double? TotalPrice => Items.Sum(x => x.Quantity * x.Product.Price);
        public DateTimeOffset CreatedAt { get; set; }
        public OrderDto()
        {
            IsOrderClosed = false;
            CreatedAt = DateTimeOffset.Now;
        }
    }

}
