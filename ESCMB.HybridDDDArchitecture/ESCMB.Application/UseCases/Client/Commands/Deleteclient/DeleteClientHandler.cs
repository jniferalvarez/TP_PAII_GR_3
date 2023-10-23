using Common.Application.Commands;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.Client.Commands.CreateClient;
using ESCMB.Application.UseCases.DummyEntity.Commands.DeleteDummyEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Commands.Deleteclient
{
    internal class DeleteClientHandler : IRequestCommandHandler<DeleteClientCommnand, Unit>
    {

        private readonly IEventPublisher _eventPublisher;
        private readonly IClientRepository _clientRepository;

        public DeleteClientHandler(IEventPublisher eventPublisher,IClientRepository clientRepository )
        {
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher)); ;
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }


        public Task<Unit> Handle(DeleteClientCommnand request, CancellationToken cancellationToken)
        {
            try
            {
                _clientRepository.Remove(request.Id);

                _eventPublisher.Publish(new ClientDelete(request.Id), cancellationToken);

                return Unit.Task;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
