using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoNivelIncidenciaConfiguration : IEntityTypeConfiguration<TipoNivelIncidencia>
{
    public void Configure(EntityTypeBuilder<TipoNivelIncidencia> builder)
    {
        builder.ToTable("TipoNivelIncidencias");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_tipoNivelIncidencia)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Descripcion)
        .HasMaxLength(100);

    }
}
