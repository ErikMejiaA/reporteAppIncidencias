namespace Dominio.Entities;
public class Incidencia : BaseEntityA
{
    public string ? Nombre_incidencia { get; set; }
    public DateTime Fecha_reporte { get; set; }
    public string ? Descripcion { get; set; }

    //foraneas
    public int Id_categoriaFK { get; set; }
    public int Id_tipoNivelIncidenciaFK { get; set; }
    public int Id_areaIncidenciaFK { get; set; }
    public string ? Id_salonFK { get; set; }
    public string ? Id_puestoFK { get; set; }
    public string ? Id_personaFK { get; set; }

    //ICollection<>
    public ICollection<EstadoIncidencia> ? EstadoIncidencias { get; set; }

    //referencias 
    public Categoria ? Categoria { get; set; }
    public TipoNivelIncidencia ? TipoNivelIncidencia { get; set; }
    public AreaIncidencia ? AreaIncidencia { get; set; }
    public Salon ? Salon { get; set; }
    public Puesto ? Puesto { get; set; }
    public Persona ? Persona { get; set; }
        
}
