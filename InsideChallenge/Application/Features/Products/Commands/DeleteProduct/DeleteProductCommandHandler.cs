using InsideChallenge.Domain.Repositories;
using MediatR;

namespace InsideChallenge.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IOrderRepository _productRepository;

        public DeleteProductCommandHandler(IOrderRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            await _productRepository.DeleteAsync(product);
            return Unit.Value;
        }
    }
}