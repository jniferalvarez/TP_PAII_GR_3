using Common.Application.Commands;
using ESCMB.Application.DataTransferObjects;

namespace ESCMB.Application.UseCases.DummyEntity.Queries.GetAllDummyEntities
{
    public class GetAllClientQuery : QueryRequestCommand<QueryResult<DummyEntityDto>>
    {
    }
}
