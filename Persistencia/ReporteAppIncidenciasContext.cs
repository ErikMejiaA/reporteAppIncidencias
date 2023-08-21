using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistencia;
public class ReporteAppIncidenciasContext : DbContext
{
    public ReporteAppIncidenciasContext(DbContextOptions<ReporteAppIncidenciasContext> options) : base(options)
    {

    }

    //aqui vana los DbSet<>
    

    //cargar las configuraciones y conexion a la base de datos 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //definimos llaves primarias compuestas
        modelBuilder.Entity<EquipoPcRecursoHwSwPc>().HasKey(p => new { p.Id_equipoFK, p.Id_recursoHwSwPcFK});

        modelBuilder.Entity<PersonaTelefonoMovil>().HasKey(p => new { p.Id_personaFK, p.Id_tipoTelefonoMovilFK});

        modelBuilder.Entity<PersonaEmail>().HasKey(p => new { p.Id_personaFK, p.Id_tipoEmailFK});

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    internal void SaveAsync()
    {

    }

}
