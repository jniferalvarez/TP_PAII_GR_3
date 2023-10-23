using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.DummyEntity.Queries.GetDummyEntityBy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.Client.Queries.GetClientById
{
    internal class GetClientByIdHandler : IRequestQueryHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IClientRepository _context;

        public GetClientByIdHandler(IClientRepository context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Client entity = await _context.FindOneAsync(request.Id);

            if (entity is null) throw new EntityDoesNotExistException();

            return entity.To<ClientDto>();
        }
    }
}
