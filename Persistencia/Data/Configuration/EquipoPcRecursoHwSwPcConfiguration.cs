using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EquipoPcRecursoHwSwPcConfiguration : IEntityTypeConfiguration<EquipoPcRecursoHwSwPc>
{
    public void Configure(EntityTypeBuilder<EquipoPcRecursoHwSwPc> builder)
    {
        builder.ToTable("EquipoPcRecursoHwSwPcs");

        builder.HasOne(p => p.EquipoPc)
        .WithMany(p => p.EquipoPcRecursoHwSwPcs)
        .HasForeignKey(p => p.Id_equipoFK)
        .IsRequired();

        builder.HasOne(p => p.RecursoHwSwPc)
        .WithMany(p => p.EquipoPcRecursoHwSwPcs)
        .HasForeignKey(p => p.Id_recursoHwSwPcFK)
        .IsRequired();
    }
}
