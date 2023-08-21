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

    //aqui van los DbSet<>
    public DbSet<AreaIncidencia> ? AreaIncidencias { get; set; }
    public DbSet<Arl> ? Arl { get; set; }
    public DbSet<Categoria> ? Categorias { get; set; }
    public DbSet<Ciudad> ? Ciudades { get; set; }
    public DbSet<Departamento> ? Departamentos { get; set; }
    public DbSet<Direccion> ? Direcciones { get; set; }
    public DbSet<Eps> ? Eps { get; set; }
    public DbSet<EquipoPc> ? EquipoPcs { get; set; }
    public DbSet<EquipoPcRecursoHwSwPc> ? EquipoPcRecursoHwSwPcs { get; set; }
    public DbSet<EstadoIncidencia> ? EstadoIncidencias { get; set; }
    public DbSet<Genero> ? Generos { get; set; }
    public DbSet<Incidencia> ? Incidencias { get; set; }
    public DbSet<Pais> ? Paises { get; set; }
    public DbSet<Persona> ? Personas { get; set; }
    public DbSet<PersonaEmail> ? PersonaEmails { get; set; }
    public DbSet<PersonaTelefonoMovil> ? PersonaTelefonoMoviles { get; set; }
    public DbSet<Puesto> ? Puestos { get; set; }
    public DbSet<RecursoHwSwPc> ? RecursoHwSwPcs { get; set; }
    public DbSet<Salon> ? Salones { get; set; }
    public DbSet<TipoEmail> ? TipoEmails { get; set; }
    public DbSet<TipoNivelIncidencia> ? TipoNivelIncidencias { get; set; }
    public DbSet<TipoPersona> ? TipoPersonas { get; set; }
    public DbSet<TipoSangre> ? TiposSangre { get; set; }
    public DbSet<TipoTelefonoMovil> ? TipoTelefonoMoviles { get; set; }

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
