namespace API.Dtos;
public class DepartamentoCiudadDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_dep { get; set; }

    //foranea
    //public int Id_paisFK { get; set; }

    //List<>
    public List<CiudadPersonaDto> ? Ciudades { get; set; }
        
}
