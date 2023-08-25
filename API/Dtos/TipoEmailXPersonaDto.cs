namespace API.Dtos;
public class TipoEmailXPersonaDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_tipoEmail { get; set; }
    public string ? Descripcion { get; set; }

    //List<>
    public List<PersonaEmailDto> ? PersonaEmails { get; set; }
        
}
