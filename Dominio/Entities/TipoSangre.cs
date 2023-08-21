namespace Dominio.Entities;
public class TipoSangre : BaseEntityA
{
    public string ? Nombre_tipoSangre { get; set; }

    //ICollection<>
    public ICollection<Persona> ? Personas { get; set; }
        
}
