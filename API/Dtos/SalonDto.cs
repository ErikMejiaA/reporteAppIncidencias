namespace API.Dtos;
public class SalonDto
{
    public string ? Id_codigo { get; set; }
    public string ? Nombre_salon { get; set; }
    public int Capasidad { get; set; }
    public string ? Descripcion { get; set; }

    //foranea 
    //public int Id_areaIncidenciaFK { get; set; }

    //List<>
    //public List<IncidenciaDto> ? Incidencias { get; set; }
    //public List<PuestoDto> ? Puestos { get; set; }
        
}
