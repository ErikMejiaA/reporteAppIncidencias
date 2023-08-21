namespace Dominio.Entities;
public class RecursoHwSwPc : BaseEntityA
{
    public string ? Nombre_recursoHwSwPc { get; set; }
    public string ? Marca { get; set; }
    public string ? Estado { get; set; }
    public string ? Version { get; set; }
    public string ? Descripcion { get; set; }

    //foranea
    public int Id_categoriaFK { get; set; }

    //ICollection<>
    public ICollection<EquipoPcRecursoHwSwPc> ? EquipoPcRecursoHwSwPcs { get; set; }

    //referencia
    public Categoria ? Categoria { get; set; }
}
