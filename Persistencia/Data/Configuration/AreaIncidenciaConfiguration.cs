using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class AreaIncidenciaConfiguration : IEntityTypeConfiguration<AreaIncidencia>
{
    public void Configure(EntityTypeBuilder<AreaIncidencia> builder)
    {
        builder.ToTable("AreaIncidencias");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_areaIncidencia)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Nombre_areaIncidencia)
        .IsUnique();

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(100);
    }
}
