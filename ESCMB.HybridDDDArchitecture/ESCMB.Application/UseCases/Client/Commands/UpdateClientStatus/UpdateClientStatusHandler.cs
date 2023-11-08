using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.UseCases.Client.Commands.UpdateClientStatus
{
    internal class UpdateClientStatusHandler : IRequestCommandHandler<UpdateClientStatusCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IEventPublisher _eventPublisher;

        public UpdateClientStatusHandler(IClientRepository clientRepository, IEventPublisher eventPublisher)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
        }

        public async Task<Unit> Handle(UpdateClientStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Domain.Entities.Client entity = await _clientRepository.FindOneAsync(request.Id);

                if (entity is null) throw new EntityDoesNotExistException();

                entity.SetStatus(ClientStatus.Confirmado.ToString());

                _clientRepository.Update(entity);

                await _eventPublisher.Publish(entity.To<ClientUpdated>(), cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
