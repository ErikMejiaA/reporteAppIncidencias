namespace API.Dtos;
public class GeneroPersonaDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_genero { get; set; }

    //List<>
    public List<PersonaDto> ? Personas { get; set; }
        
}
