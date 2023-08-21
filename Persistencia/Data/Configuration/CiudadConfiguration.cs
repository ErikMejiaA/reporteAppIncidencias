using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("Ciudades");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_ciudad)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Nombre_ciudad)
        .IsUnique();

        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Ciudades)
        .HasForeignKey(p => p.Id_departamentoFK)
        .IsRequired();
    }
}
