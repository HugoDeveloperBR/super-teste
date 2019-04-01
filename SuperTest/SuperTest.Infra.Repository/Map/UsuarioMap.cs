using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperTest.Domain.Entities.Usuarios;

namespace SuperTest.Infra.Repository.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "Usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(u => u.CPF)
                .Property(c => c.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(u => u.Email).HasName("email_index").IsUnique();
        }
    }
}
