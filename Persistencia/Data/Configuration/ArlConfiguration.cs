using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ArlConfiguration : IEntityTypeConfiguration<Arl>
{
    public void Configure(EntityTypeBuilder<Arl> builder)
    {
        builder.ToTable("Arl");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_arl)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.Telefono)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(p => p.Descripcion)
        .HasMaxLength(100);

    }
}
