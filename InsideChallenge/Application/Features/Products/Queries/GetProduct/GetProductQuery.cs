using InsideChallenge.Application.Persistence;
using MediatR;

namespace InsideChallenge.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQuery :IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
