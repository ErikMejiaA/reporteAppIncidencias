using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoSangreConfiguration : IEntityTypeConfiguration<TipoSangre>
{
    public void Configure(EntityTypeBuilder<TipoSangre> builder)
    {
        builder.ToTable("TiposSangre");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_tipoSangre)
        .IsRequired()
        .HasMaxLength(5);

        builder.HasIndex(p => p.Nombre_tipoSangre)
        .IsUnique();

    }
}
