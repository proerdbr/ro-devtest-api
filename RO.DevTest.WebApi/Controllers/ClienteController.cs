using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RO.DevTest.Application.Features.Cliente.Commands.CreateClienteCommand;
using RO.DevTest.Application.Features.Cliente.Commands.UpdateClienteCommand;
using RO.DevTest.Application.Features.Cliente.Queries.GetAllClientes;

namespace RO.DevTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        [HttpPost]
        [Authorize] // você pode remover isso se quiser testar sem login
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        [HttpGet]
        [Authorize] // você pode remover isso se quiser testar sem login
        public async Task<IActionResult> GetAllClientes()
        {
            var query = new GetAllClientesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Atualiza os dados de um cliente existente
        /// </summary>
        [HttpPut("{id}")]
        [Authorize] // você pode remover isso se quiser testar sem login
        public async Task<IActionResult> UpdateCliente(Guid id, [FromBody] UpdateClienteCommand command)
        {
            if (id != command.Id)
                return BadRequest("O ID da URL não corresponde ao ID do corpo da requisição.");

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound("Cliente não encontrado.");

            return NoContent();
        }
    }
}
