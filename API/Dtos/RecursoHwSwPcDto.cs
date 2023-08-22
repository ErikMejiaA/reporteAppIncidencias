namespace API.Dtos;
public class RecursoHwSwPcDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_recursoHwSwPc { get; set; }
    public string ? Marca { get; set; }
    public string ? Estado { get; set; }
    public string ? Version { get; set; }
    public string ? Descripcion { get; set; }

    //foranea
    //public int Id_categoriaFK { get; set; }

    //List<>
    //public List<EquipoPcRecursoHwSwPcDto> ? EquipoPcRecursoHwSwPcs { get; set; }
        
}
