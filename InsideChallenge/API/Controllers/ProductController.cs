using InsideChallenge.Application.Features.Products.Commands.CreateProduct;
using InsideChallenge.Application.Features.Products.Commands.DeleteProduct;
using InsideChallenge.Application.Features.Products.Commands.UpdateProduct;
using InsideChallenge.Application.Features.Products.Queries.GetProduct;
using InsideChallenge.Application.Features.Products.Queries.ListProducts;
using InsideChallenge.Application.Persistence;
using InsideChallenge.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsideChallenge.API.Controllers
{
    //Estes endpoints só estão expostos somente para ajudar a utilização da aplicação
    //e verificação das funcionalidades
    [Route("api/produtos")]
    public class ProductController : APIController
    {
        private readonly IOrderRepository _productRepository;
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var query = new GetProductQuery() { Id = id };
            var product = await _mediator.Send(query);
            return Ok(product);
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> ListProducts()
        {
            var query = new ListProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProduct), new { id = product }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            var updatedCommand = new UpdateProductCommand (id,command.Name,command.Price );
            await _mediator.Send(updatedCommand);
            return NoContent();
        }
    }
}
