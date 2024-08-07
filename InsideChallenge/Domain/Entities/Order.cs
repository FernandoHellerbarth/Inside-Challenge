namespace InsideChallenge.Domain.Entities
{
    public class Order : BaseEntity
    {
        public bool IsOrderClosed { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public double? TotalPrice => Items.Sum(x => x.Quantity * x.Product.Price);
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public Order()
        {
            IsOrderClosed = false;
            CreatedAt = DateTimeOffset.Now;
        }

    }
}
