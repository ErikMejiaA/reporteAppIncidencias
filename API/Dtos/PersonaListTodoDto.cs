
namespace API.Dtos;

public class PersonaListTodoDto
{
    public string ? Id_codigo { get; set; }
    public string ? Nombre { get; set; }
    public string ? Apellido { get; set; }
    public int Edad { get; set; }
    public string ? Nro_documento { get; set; }
    public int Estrato_social { get; set; }
    public string ? Cargo { get; set; }

    //foraneas 
    //public int Id_ciudadFK { get; set; }
    //public int Id_generoFK { get; set; }
    //public int Id_tipoSangreFK { get; set; }
    //public int Id_tipoPersonaFK { get; set; }
    //public int Id_epsFK { get; set; }
    //public int Id_arlFK { get; set; }

    //List<>
    public List<IncidenciaDto> ? Incidencias { get; set; }
    public List<DireccionDto> ? Direcciones { get; set; }
    public List<PersonaTelefonoMovilDto> ? PersonaTelefonoMoviles { get; set; }
    public List<PersonaEmailDto> ? PersonaEmails { get; set; }
}
