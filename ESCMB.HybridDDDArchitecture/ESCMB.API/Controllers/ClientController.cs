using Common.Application.Commands;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.UseCases.Client.Commands.CreateClient;
using ESCMB.Application.UseCases.Client.Commands.Deleteclient;
using ESCMB.Application.UseCases.Client.Commands.UpdateClient;
using ESCMB.Application.UseCases.Client.Queries.GetAllClient;
using ESCMB.Application.UseCases.Client.Queries.GetClientById;
using ESCMB.Application.UseCases.DummyEntity.Queries.GetDummyEntityBy;
using Microsoft.AspNetCore.Mvc;
using static ESCMB.Domain.Enums;

namespace ESCMB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IEventPublisher _commandQueryBus;
        public ClientController(IEventPublisher commandQueryBus)
        {
            _commandQueryBus = commandQueryBus ?? throw new ArgumentNullException(nameof(commandQueryBus));
        }

        [HttpPost("api/v1/[Controller]")]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
            if (command is null) return BadRequest();

            var id = await _commandQueryBus.Send(command);

            return Created($"api/[Controller]/{id}", new { Id = id });
        }

        [HttpDelete("api/v1/[Controller]/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();

            await _commandQueryBus.Send(new DeleteClientCommnand { Id = id });

            return NoContent();
        }

        [HttpPut("api/v1/[Controller]")]
        public async Task<IActionResult> Update(UpdateClientCommand command)
        {
            if (command is null) return BadRequest();

            await _commandQueryBus.Send(command);

            return NoContent();
        }

        [HttpGet("api/v1/[Controller]")]
        public async Task<IActionResult> GetAll(int pageIndex = 1, int pageSize = 10)
        {
            QueryResult<ClientDto>? client = await _commandQueryBus.Send(new GetAllClientQuery() { PageIndex = pageIndex, PageSize = pageSize });

            return Ok(client);
        }

        [HttpGet("api/v1/[Controller]/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();
            
            var entity = await _commandQueryBus.Send(new GetClientByIdQuery { Id = id });

                return Ok(entity);


        }

        [HttpPut("api/v1/confirmar")]
        public async Task<IActionResult> ConfirmarCorreoAsync([FromBody] string token)
        {
            // Valida el token y encuentra el cliente asociado
            var entity = await _commandQueryBus.Send(new GetClientByIdQuery { Id = token });


            if (entity == null)
            {
                return BadRequest("ID inválido o está rengo");
            }

            // Actualiza la información del cliente
            entity.Status = ClientStatus.Confirmado.ToString();

            // Guarda los cambios en la base de datos
            await _commandQueryBus.Send(new UpdateClientCommand
            {
                Id = entity.Id,
                Apellido = entity.Apellido,
                CuitCuil = (long)entity.CuitCuil,
                //Email = entity.Email,
                //Nombre = entity.Nombre,
                //Status = entity.Status
            });

            return Ok("Correo confirmado con éxito");
        }


    }
}
