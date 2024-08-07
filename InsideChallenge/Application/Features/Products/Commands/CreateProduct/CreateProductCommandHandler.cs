using AutoMapper;
using InsideChallenge.Domain.Entities;
using InsideChallenge.Domain.Repositories;
using MediatR;

namespace InsideChallenge.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.CreateAsync(product);
            return product.Id;
        }
    }
}
