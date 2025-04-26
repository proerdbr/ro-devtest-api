using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Produto.Commands.CreateProdutoCommand;
using RO.DevTest.Application.Features.Produto.Commands.UpdateProdutoCommand;
using RO.DevTest.Application.Features.Produto.Commands.DeleteProdutoCommand;
using RO.DevTest.Application.Features.Produto.Queries.GetAllProdutos;

namespace RO.DevTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        [HttpPost]
        [Authorize] // você pode remover isso para testes locais sem login
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Lista todos os produtos com paginação
        /// </summary>
        [HttpGet]
        [Authorize] // você pode remover isso para testes locais sem login
        public async Task<IActionResult> GetAllProdutos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllProdutosQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Atualiza os dados de um produto existente
        /// </summary>
        [HttpPut("{id}")]
        [Authorize] // você pode remover isso para testes locais sem login
        public async Task<IActionResult> UpdateProduto(Guid id, [FromBody] UpdateProdutoCommand command)
        {
            if (id != command.Id)
                return BadRequest("O ID da URL não corresponde ao ID do corpo da requisição.");

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("Produto não encontrado.");

            return NoContent();
        }

        /// <summary>
        /// Remove um produto pelo ID
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize] // você pode remover isso para testes locais sem login
        public async Task<IActionResult> DeleteProduto(Guid id)
        {
            var command = new DeleteProdutoCommand { Id = id };

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("Produto não encontrado.");

            return NoContent();
        }
    }
}
