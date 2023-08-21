using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class IncidenciaConfiguration : IEntityTypeConfiguration<Incidencia>
{
    public void Configure(EntityTypeBuilder<Incidencia> builder)
    {
        builder.ToTable("Incidencias");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_incidencia)
        .IsRequired()
        .HasMaxLength(150);

        builder.Property(p => p.Fecha_reporte)
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(200);

        builder.HasOne(p => p.Categoria)
        .WithMany(p => p.Incidencias)
        .HasForeignKey(p => p.Id_categoriaFK)
        .IsRequired();

        builder.HasOne(p => p.TipoNivelIncidencia)
        .WithMany(p => p.Incidencias)
        .HasForeignKey(p => p.Id_tipoNivelIncidenciaFK)
        .IsRequired();

        builder.HasOne(p => p.AreaIncidencia)
        .WithMany(p => p.Incidencias)
        .HasForeignKey(p => p.Id_areaIncidenciaFK)
        .IsRequired();

        builder.HasOne(p => p.Salon)
        .WithMany(p => p.Incidencias)
        .HasForeignKey(p => p.Id_salonFK)
        .IsRequired();

        builder.HasOne(p => p.Puesto)
        .WithMany(p => p.Incidencias)
        .HasForeignKey(p => p.Id_puestoFK)
        .IsRequired();

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Incidencias)
        .HasForeignKey(p => p.Id_personaFK)
        .IsRequired();
    }
}
