namespace Dominio.Entities;
public class TipoPersona : BaseEntityA
{
    public string ? Nombre_tipoPersona { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    public ICollection<Persona> ? Personas { get; set; }
        
}
