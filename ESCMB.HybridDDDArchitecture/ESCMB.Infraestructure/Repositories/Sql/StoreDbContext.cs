using ESCMB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ESCMB.Infraestructure.Repositories.Sql
{
    /// <summary>
    /// Contexto de almacenamiento en base de datos. Aca se definen los nombres de 
    /// las tablas, y los mapeos entre los objetos
    /// </summary>
    internal sealed class StoreDbContext : DbContext
    {
        //public DbSet<Domain.Entities.DummyEntity> DummyEntity { get; set; }
        public DbSet<Client> ClientEntity { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("cliente");

            modelBuilder.Entity<Client>().Ignore(type => type.ValidationErrors);
            modelBuilder.Entity<Client>().Ignore(type => type.IsValid);

            //modelBuilder.Entity<Domain.Entities.DummyEntity>().ToTable("DummyEntity");

            //modelBuilder.Entity<Domain.Entities.DummyEntity>().Ignore(type => type.ValidationErrors);
            //modelBuilder.Entity<Domain.Entities.DummyEntity>().Ignore(type => type.IsValid);
        }
    }
}
