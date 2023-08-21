namespace Dominio.Entities;
public class Ciudad : BaseEntityA
{
    public string ? Nombre_ciudad { get; set; }

    //foranea
    public int Id_departamentoFK { get; set; }

    //ICollection<>
    public ICollection<Persona> ? Personas { get; set; }

    //referencia 
    public Departamento ? Departamento { get; set; }

}
