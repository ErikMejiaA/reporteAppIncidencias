using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PuestoConfiguration : IEntityTypeConfiguration<Puesto>
{
    public void Configure(EntityTypeBuilder<Puesto> builder)
    {
        builder.ToTable("Puestos");

        builder.Property(p => p.Id_codigo)
        .IsRequired()
        .HasMaxLength(20);

        builder.HasIndex(p => p.Id_codigo)
        .IsUnique();

        builder.Property(p => p.Nombre_puesto)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasMaxLength(30);

        builder.HasOne(p => p.Salon)
        .WithMany(p => p.Puestos)
        .HasForeignKey(p => p.Id_salonFK)
        .IsRequired();

        builder.HasOne(p => p.EquipoPc)
        .WithOne(p => p.Puesto)
        .HasForeignKey<Puesto>(p => p.Id_equipoFK)
        .IsRequired();
    }
}
