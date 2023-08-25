namespace API.Dtos;
public class TipoSangreXpersonaDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_tipoSangre { get; set; }

    //List<>
    public List<PersonaDto> ? Personas { get; set; }
        
}
