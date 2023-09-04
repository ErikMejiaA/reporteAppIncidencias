
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.Property(p => p.Id_codigo)
        .IsRequired();

        builder.Property(p => p.Username)
        .IsRequired()
        .HasMaxLength(200);

        builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(200);
        
        builder.HasIndex(p => p.Username)
        .IsUnique();

        builder.HasIndex(p => p.Email)
        .IsUnique();

        //se define la configuracion de la entidad UsuariosRoles
        builder
        .HasMany(p => p.Roles)
        .WithMany(p => p.Usuarios)
        .UsingEntity<UsuariosRoles> (
            j => j
                .HasOne(p => p.Rol)
                .WithMany(p => p.UsuariosRoles)
                .HasForeignKey(p => p.RolId),

            j => j
                .HasOne(p => p.Usuario)
                .WithMany(p => p.UsuariosRoles)
                .HasForeignKey(p => p.UsuarioId),

            j => 
                {
                    j.HasKey(p => new { p.UsuarioId, p.RolId});
                }
        );

    }
}
