using InsideChallenge.Domain.Entities;

namespace InsideChallengeUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Order_ShouldInitializeWithDefaults()
        {
            var order = new Order();

            Assert.False(order.IsOrderClosed);
            Assert.Empty(order.Items);
            Assert.Equal(DateTimeOffset.Now.Date, order.CreatedAt.Date);
        }

        [Fact]
        public void Order_ShouldCalculateTotalPrice()
        {
            var order = new Order();

            order.Items.Add(new OrderItem
            {
                Quantity = 2,
                Product = new Product { Price = 10.0 }
            });
            order.Items.Add(new OrderItem
            {
                Quantity = 1,
                Product = new Product { Price = 5.0 }
            });

            var totalPrice = order.TotalPrice;

            Assert.Equal(25.0, totalPrice);
        }

        [Fact]
        public void Order_ShouldAddOrderItem()
        {

            var order = new Order();
            var orderItem = new OrderItem
            {
                Quantity = 1,
                Product = new Product { Price = 5.0 }
            };

            order.Items.Add(orderItem);

            Assert.Single(order.Items);
            Assert.Equal(orderItem, order.Items.First());
        }

        [Fact]
        public void OrderItem_ShouldInitializeWithDefaults()
        {
            var orderItem = new OrderItem();

            Assert.Null(orderItem.Order);
            Assert.Null(orderItem.Product);
            Assert.Equal(0, orderItem.Quantity);
        }

        [Fact]
        public void Product_ShouldInitializeWithDefaults()
        {
            var product = new Product();

            Assert.Null(product.Name);
            Assert.Equal(0, product.Price);
        }
    }
}