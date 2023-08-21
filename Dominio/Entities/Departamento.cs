namespace Dominio.Entities;
public class Departamento : BaseEntityA
{
    public string ? Nombre_dep { get; set; }

    //foranea
    public int Id_paisFK { get; set; }

    //ICollection<>
    public ICollection<Ciudad> ? Ciudades { get; set; }

    //referencia 
    public Pais ? Pais { get; set; }
        
}
