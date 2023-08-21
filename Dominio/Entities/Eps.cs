namespace Dominio.Entities; 
public class Eps : BaseEntityA
{
    public string ? Nombre_eps { get; set; }
    public string ? Email { get; set; }
    public string ? Telefono { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    public ICollection<Persona> ? Personas { get; set; }
    
}
