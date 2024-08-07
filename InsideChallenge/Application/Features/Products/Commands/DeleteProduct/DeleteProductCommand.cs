using MediatR;

namespace InsideChallenge.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}