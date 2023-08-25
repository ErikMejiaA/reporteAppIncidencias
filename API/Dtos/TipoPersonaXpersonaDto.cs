namespace API.Dtos;
public class TipoPersonaXpersonaDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_tipoPersona { get; set; }
    public string ? Descripcion { get; set; }

    //List<>
    public List<PersonaDto> ? Personas { get; set; }
        
}
