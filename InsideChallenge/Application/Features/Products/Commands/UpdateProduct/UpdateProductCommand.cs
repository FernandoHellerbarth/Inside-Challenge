using MediatR;
using System.Text.Json.Serialization;

namespace InsideChallenge.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public UpdateProductCommand(int id,string name,double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
