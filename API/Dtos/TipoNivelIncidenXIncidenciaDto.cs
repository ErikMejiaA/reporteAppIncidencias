namespace API.Dtos;
public class TipoNivelIncidenXIncidenciaDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_tipoNivelIncidencia { get; set; }
    public string ? Descripcion { get; set; }

    //List<>
    public List<IncidenciaDto> ? Incidencias { get; set; } 
        
}
