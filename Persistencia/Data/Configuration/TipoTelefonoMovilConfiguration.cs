using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoTelefonoMovilConfiguration : IEntityTypeConfiguration<TipoTelefonoMovil>
{
    public void Configure(EntityTypeBuilder<TipoTelefonoMovil> builder)
    {
        builder.ToTable("TipoTelefonoMoviles");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_tipoTelMov)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Descripcion)
        .HasMaxLength(100);
    }
}
