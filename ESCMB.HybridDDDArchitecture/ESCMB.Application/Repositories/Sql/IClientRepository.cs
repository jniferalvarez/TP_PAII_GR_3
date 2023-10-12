using Common.Application.Repositories.Sql;
using ESCMB.Domain.Entities;

namespace ESCMB.Application.Repositories.Sql
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<string> AddOneAsync(Client entity);
    }
}
