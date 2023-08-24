namespace API.Dtos;
public class AreaIncidenciaSalonDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_areaIncidencia { get; set; }
    public string ? Descripcion { get; set; }

    //List<>
    public List<IncidenciaDto> ? Incidencias { get; set; }
    public List<SalonDto> ? Salones { get; set; }
        
}
