using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.UseCases.Client.Queries.GetAllClient
{
    internal sealed class GetAllClientHandler : IRequestQueryHandler<GetAllClientQuery, QueryResult<ClientDto>>
    {
        private readonly IClientRepository _context;

        public GetAllClientHandler(IClientRepository context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<QueryResult<ClientDto>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            IList<Domain.Entities.Client> client = await _context.FindAllAsync();

            return new QueryResult<ClientDto>(client.To<ClientDto>(), client.Count, request.PageIndex, request.PageSize);
        }

    }
}
