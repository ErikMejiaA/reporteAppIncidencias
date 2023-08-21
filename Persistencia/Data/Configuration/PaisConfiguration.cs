using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("Paises");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_pais)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Nombre_pais)
        .IsUnique();
    }
}
