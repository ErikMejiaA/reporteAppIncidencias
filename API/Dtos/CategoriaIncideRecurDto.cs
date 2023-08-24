namespace API.Dtos;
public class CategoriaIncideRecurDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_categoria { get; set; }
    public string ? Descripcion { get; set; }

    //LIst<>
    public List<IncidenciaDto> ? Incidencias { get; set; }
    public List<RecursoHwSwPcDto> ? RecursoHwSwPcs { get; set; }
        
}
