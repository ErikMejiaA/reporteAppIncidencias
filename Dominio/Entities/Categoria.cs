namespace Dominio.Entities;
public class Categoria : BaseEntityA
{
    public string ? Nombre_categoria { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    public ICollection<Incidencia> ? Incidencias { get; set; }
    public ICollection<RecursoHwSwPc> ? RecursoHwSwPcs { get; set; }
        
}
