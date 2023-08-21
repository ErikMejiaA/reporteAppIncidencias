using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoPersonaCofiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.ToTable("TipoPersonas");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_tipoPersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Nombre_tipoPersona)
        .IsUnique();

        builder.Property(p => p.Descripcion)
        .HasMaxLength(100);
    }
}
