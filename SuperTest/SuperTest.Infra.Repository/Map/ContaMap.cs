using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperTest.Domain.Entities.Usuarios;

namespace SuperTest.Infra.Repository.Map
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta", "Usuario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Senha)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

