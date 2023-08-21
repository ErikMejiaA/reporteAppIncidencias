using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamentos");

        builder.Property(p => p.Nombre_dep)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.Nombre_dep)
        .IsUnique();

        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(p => p.Id_paisFK)
        .IsRequired();

    }
}
