using AutoMapper;
using InsideChallenge.Domain.Repositories;
using MediatR;

namespace InsideChallenge.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler :IRequestHandler<UpdateProductCommand,Unit>
    {
        private readonly IOrderRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IOrderRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, product);

            await _productRepository.UpdateAsync(product);
            return Unit.Value;
        }
    }
}
