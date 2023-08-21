namespace Dominio.Entities;
public class Pais : BaseEntityA
{
    public string ? Nombre_pais { get; set; }

    //ICollection<>
    public ICollection<Departamento> ? Departamentos { get; set; }

        
}
