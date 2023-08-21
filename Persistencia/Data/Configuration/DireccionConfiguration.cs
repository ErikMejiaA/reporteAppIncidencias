using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("Direcciones");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Calle)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.Carrera)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.Numero)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(p => p.Letra)
        .IsRequired()
        .HasMaxLength(1);

        builder.Property(p => p.Diagonal)
        .HasMaxLength(10);

        builder.Property(p => p.Barrio)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Nro_puerta)
        .HasMaxLength(10);

        builder.Property(p => p.Tipo_residencia)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Direcciones)
        .HasForeignKey(p => p.Id_personaFK)
        .IsRequired();

    }
}
