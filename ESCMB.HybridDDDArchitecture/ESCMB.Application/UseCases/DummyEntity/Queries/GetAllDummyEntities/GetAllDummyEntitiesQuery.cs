using Common.Application.Commands;
using ESCMB.Application.DataTransferObjects;

namespace ESCMB.Application.UseCases.Client.Queries
{
    public class GetAllDummyEntitiesQuery : QueryRequestCommand<QueryResult<DummyEntityDto>>
    {
    }
}
