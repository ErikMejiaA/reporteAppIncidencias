namespace Dominio.Entities;
public class Genero : BaseEntityA
{
    public string ? Nombre_genero { get; set; }

    //ICollection<>
    public ICollection<Persona> ? Personas { get; set; }
        
}
