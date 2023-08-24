namespace API.Dtos;
public class EpsPersonaDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_eps { get; set; }
    public string ? Email { get; set; }
    public string ? Telefono { get; set; }
    public string ? Descripcion { get; set; }

    //List<>
    public List<PersonaDto> ? Personas { get; set; }
        
}
