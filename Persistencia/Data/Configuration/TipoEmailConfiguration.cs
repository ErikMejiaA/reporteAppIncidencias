using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoEmailConfiguration : IEntityTypeConfiguration<TipoEmail>
{
    public void Configure(EntityTypeBuilder<TipoEmail> builder)
    {
        builder.ToTable("TipoEmails");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_tipoEmail)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Descripcion)
        .HasMaxLength(100);

    }
}
