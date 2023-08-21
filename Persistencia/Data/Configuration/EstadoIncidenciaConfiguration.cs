using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EstadoIncidenciaConfiguration : IEntityTypeConfiguration<EstadoIncidencia>
{
    public void Configure(EntityTypeBuilder<EstadoIncidencia> builder)
    {
        builder.ToTable("EstadoIncidencias");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasOne(p => p.Incidencia)
        .WithMany(p => p.EstadoIncidencias)
        .HasForeignKey(p => p.Id_incidenciaFK)
        .IsRequired();

    }
}
