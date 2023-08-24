namespace API.Dtos;
public class CiudadPersonaDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_ciudad { get; set; }

    //foranea
    //public int Id_departamentoFK { get; set; }

    //List<>
    public List<PersonaDto> ? Personas { get; set; }
        
}
