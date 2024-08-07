using InsideChallenge.Application.Persistence;
using MediatR;

namespace InsideChallenge.Application.Features.Products.Queries.ListProducts
{
    public class ListProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
