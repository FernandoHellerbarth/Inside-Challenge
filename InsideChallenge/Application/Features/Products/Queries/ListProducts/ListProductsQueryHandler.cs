using AutoMapper;
using InsideChallenge.Application.Features.Products.Queries.GetProduct;
using InsideChallenge.Application.Persistence;
using InsideChallenge.Domain.Repositories;
using MediatR;

namespace InsideChallenge.Application.Features.Products.Queries.ListProducts
{
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
