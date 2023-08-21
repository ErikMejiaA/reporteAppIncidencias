using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("Generos");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_genero)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Nombre_genero)
        .IsUnique();
    }
}
