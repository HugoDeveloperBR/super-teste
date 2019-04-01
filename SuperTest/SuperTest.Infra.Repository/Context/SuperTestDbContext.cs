using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperTest.Domain.Entities.Usuarios;
using SuperTest.Infra.Repository.Map;
using System.IO;

namespace SuperTest.Infra.Repository.Context
{
    public class SuperTestDbContext : DbContext
    {
        public SuperTestDbContext(DbContextOptions<SuperTestDbContext> options)
            :base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ContaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
