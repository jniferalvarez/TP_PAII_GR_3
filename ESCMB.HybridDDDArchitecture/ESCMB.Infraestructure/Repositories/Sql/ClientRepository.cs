using Common.Infraestructure.Repositories.Sql;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Domain.Entities;

namespace ESCMB.Infraestructure.Repositories.Sql
{
    internal class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(StoreDbContext context) : base(context)
        {
        }

        public async Task<string> AddOneAsync(Client entity)
        {
            entity = entity ?? throw new ArgumentNullException(nameof(entity));

            try
            {
                await Repository.AddAsync(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return Context.Entry(entity).Property("Id").CurrentValue.ToString();
        }
    }
}
