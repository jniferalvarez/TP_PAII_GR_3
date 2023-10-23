using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.DummyEntity.Commands.UpdateDummyEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.UpdateClient
{
    internal class UpdateClientHandler : IRequestCommandHandler<UpdateClientCommand>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClientRepository _clientRepository;

        public UpdateClientHandler(IEventPublisher eventPublisher, IClientRepository clientRepository)
        {
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }
        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Client entity = await _clientRepository.FindOneAsync(request.CuitCuil);

            if (entity is null) throw new EntityDoesNotExistException();

            entity.SetLastName(request.Apellido);
            entity.SetName(request.Nombre);
            entity.SetEmail(request.Email);
            try
            {
                _clientRepository.Update(entity);

                await _eventPublisher.Publish(entity.To<ClientUpdate>(), cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
