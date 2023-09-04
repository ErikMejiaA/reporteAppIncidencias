namespace Dominio.Entities;
public class Persona : BaseEntityB
{
    public string ? Nombre { get; set; }
    public string ? Apellido { get; set; }
    public int Edad { get; set; }
    public string ? Nro_documento { get; set; }
    public int Estrato_social { get; set; }
    public string ? Cargo { get; set; }

    //foraneas 
    public int Id_ciudadFK { get; set; }
    public int Id_generoFK { get; set; }
    public int Id_tipoSangreFK { get; set; }
    //public int Id_tipoPersonaFK { get; set; }
    public int Id_epsFK { get; set; }
    public int ? Id_arlFK { get; set; }

    //ICollection<>
    public ICollection<Incidencia> ? Incidencias { get; set; }
    public ICollection<Direccion> ? Direcciones { get; set; }
    public ICollection<PersonaTelefonoMovil> ? PersonaTelefonoMoviles { get; set; }
    public ICollection<PersonaEmail> ? PersonaEmails { get; set; }

    //referencia 
    public Ciudad ? Ciudad { get; set; }
    public Genero ? Genero { get; set; }
    public TipoSangre ? TipoSangre { get; set; }
    //public TipoPersona ? TipoPersona { get; set; }
    public Eps ? Eps { get; set; }
    public Arl ? Arl { get; set; }

}
