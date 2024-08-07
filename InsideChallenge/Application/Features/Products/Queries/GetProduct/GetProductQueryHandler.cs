using AutoMapper;
using InsideChallenge.Application.Persistence;
using InsideChallenge.Domain.Repositories;
using MediatR;

namespace InsideChallenge.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}