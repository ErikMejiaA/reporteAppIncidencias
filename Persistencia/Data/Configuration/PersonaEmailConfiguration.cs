using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PersonaEmailConfiguration : IEntityTypeConfiguration<PersonaEmail>
{
    public void Configure(EntityTypeBuilder<PersonaEmail> builder)
    {
        builder.ToTable("PersonaEmails");

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasIndex(p => p.Email)
        .IsUnique();

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.PersonaEmails)
        .HasForeignKey(p => p.Id_personaFK)
        .IsRequired();

        builder.HasOne(p => p.TipoEmail)
        .WithMany(p => p.PersonaEmails)
        .HasForeignKey(p => p.Id_tipoEmailFK)
        .IsRequired();

    }
}
