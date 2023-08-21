using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_categoria)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Nombre_categoria)
        .IsUnique();

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(100);

    }
}
