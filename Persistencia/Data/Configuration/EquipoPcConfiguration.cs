using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EquipoPcConfiguration : IEntityTypeConfiguration<EquipoPc>
{
    public void Configure(EntityTypeBuilder<EquipoPc> builder)
    {
        builder.ToTable("EquipoPcs");

        builder.Property(p => p.Id_codigo)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasIndex(p => p.Id_codigo)
        .IsUnique();

        builder.Property(p => p.Nombre_referenciaPc)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Nombre_referenciaPc)
        .IsUnique();

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasMaxLength(30);

        builder.Property(p => p.Marca)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Descripcion)
        .HasMaxLength(100);

    }
}
