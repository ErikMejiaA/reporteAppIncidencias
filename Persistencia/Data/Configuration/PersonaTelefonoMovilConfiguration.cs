using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PersonaTelefonoMovilConfiguration : IEntityTypeConfiguration<PersonaTelefonoMovil>
{
    public void Configure(EntityTypeBuilder<PersonaTelefonoMovil> builder)
    {
        builder.ToTable("PersonaTelefonoMovils");

        builder.Property(p => p.Numero_telefonoMovil)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.PersonaTelefonoMoviles)
        .HasForeignKey(p => p.Id_personaFK)
        .IsRequired();

        builder.HasOne(p => p.TipoTelefonoMovil)
        .WithMany(p => p.PersonaTelefonoMoviles)
        .HasForeignKey(p => p.Id_tipoTelefonoMovilFK)
        .IsRequired();
    }
}
