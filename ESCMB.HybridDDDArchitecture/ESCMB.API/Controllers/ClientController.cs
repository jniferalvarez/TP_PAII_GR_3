using Common.Application.Commands;
using ESCMB.Application.UseCases.Client.Commands.CreateClient;
using ESCMB.Application.UseCases.Client.Commands.Deleteclient;
using ESCMB.Application.UseCases.Client.Commands.UpdateClient;
using ESCMB.Application.UseCases.DummyEntity.Commands.CreateDummyEntity;
using ESCMB.Application.UseCases.DummyEntity.Commands.DeleteDummyEntity;
using ESCMB.Application.UseCases.DummyEntity.Commands.UpdateDummyEntity;
using ESCMB.Application.UseCases.DummyEntity.Queries.GetAllDummyEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            QueryResult<Application.DataTransferObjects.ClientDto>? client = await _commandQueryBus.Send(new GetAllClientQuery() { PageIndex = pageIndex, PageSize = pageSize });

            return Ok(client);
        }

    }
}
