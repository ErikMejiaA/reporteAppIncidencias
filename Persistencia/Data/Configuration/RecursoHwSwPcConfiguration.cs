using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class RecursoHwSwPcConfiguration : IEntityTypeConfiguration<RecursoHwSwPc>
{
    public void Configure(EntityTypeBuilder<RecursoHwSwPc> builder)
    {
        builder.ToTable("RecursoHwSwPcs");

        builder.Property(p => p.Id_codigo);

        builder.Property(p => p.Nombre_recursoHwSwPc)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Marca)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Estado)
        .IsRequired()
        .HasMaxLength(30);

        builder.Property(p => p.Version)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Descripcion)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasOne(p => p.Categoria)
        .WithMany(p => p.RecursoHwSwPcs)
        .HasForeignKey(p => p.Id_categoriaFK)
        .IsRequired();

    }
}
