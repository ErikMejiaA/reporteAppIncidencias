using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class SalonConfiguration : IEntityTypeConfiguration<Salon>
{
    public void Configure(EntityTypeBuilder<Salon> builder)
    {
        builder.ToTable("Salones");

        builder.Property(p => p.Id_codigo)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasIndex(p => p.Id_codigo)
        .IsUnique();

        builder.Property(p => p.Nombre_salon)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Capasidad)
        .IsRequired();

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasOne(p => p.AreaIncidencia)
        .WithMany(p => p.Salones)
        .HasForeignKey(p => p.Id_areaIncidenciaFK)
        .IsRequired();

    }
}
