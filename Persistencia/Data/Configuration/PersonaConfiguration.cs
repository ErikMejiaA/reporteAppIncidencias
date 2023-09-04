using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Personas");

        builder.Property(p => p.Id_codigo)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasIndex(p => p.Id_codigo)
        .IsUnique();

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Apellido)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Edad)
        .IsRequired();

        builder.Property(p => p.Nro_documento)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(p => p.Estrato_social)
        .IsRequired()
        .HasColumnType("int(2)");

        builder.Property(p => p.Cargo)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p => p.Ciudad)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.Id_ciudadFK)
        .IsRequired();

        builder.HasOne(p => p.Genero)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.Id_generoFK)
        .IsRequired();

        builder.HasOne(p => p.TipoSangre)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.Id_tipoSangreFK)
        .IsRequired();

        /*builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.Id_tipoPersonaFK)
        .IsRequired();*/

        builder.HasOne(p => p.Eps)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.Id_epsFK)
        .IsRequired();

        builder.HasOne(p => p.Arl)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.Id_arlFK)
        .IsRequired();

    }
}
