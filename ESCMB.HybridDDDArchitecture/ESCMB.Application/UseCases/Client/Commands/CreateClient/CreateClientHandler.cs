using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.UseCases.Client.Commands.CreateClient
{
    internal class CreateClientHandler : IRequestCommandHandler<CreateClientCommand, string>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClientRepository _clientRepository;
        public CreateClientHandler(IEventPublisher eventPublisher, IClientRepository clientRepository)
        {
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<string> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            //TODO: Falta logica busqueda de cliente por CuitCuil para validar si ya esta dado de alta

            Domain.Entities.Client client = new Domain.Entities.Client(request.Apellido, request.CuitCuil, request.Email, request.Nombre);

            if (!client.IsValid)
            {
                throw new InvalidEntityDataException(client.ValidationErrors);
            }

            string id = await _clientRepository.AddOneAsync(client).ConfigureAwait(false);

            await _eventPublisher.Publish(client.To<ClientCreated>(), cancellationToken).ConfigureAwait(false);

            return id;
        }
    }
}
