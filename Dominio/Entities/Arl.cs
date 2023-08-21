namespace Dominio.Entities;
public class Arl : BaseEntityA
{
    public string ? Nombre_arl { get; set; }
    public string ? Email { get; set; }
    public string ? Telefono { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    public ICollection<Persona> ? Personas { get; set; }
       
}
