namespace API.Dtos;
public class IncidenciaPorEstadoDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_incidencia { get; set; }
    public DateTime Fecha_reporte { get; set; }
    public string ? Descripcion { get; set; }

    //foraneas
    //public int Id_categoriaFK { get; set; }
    //public int Id_tipoNivelIncidenciaFK { get; set; }
    //public int Id_areaIncidenciaFK { get; set; }
    //public string ? Id_salonFK { get; set; }
    //public string ? Id_puestoFK { get; set; }
    //public string ? Id_personaFK { get; set; }

    //List<>
    public List<EstadoIncidenciaDto> ? EstadoIncidencias { get; set; }
        
}
