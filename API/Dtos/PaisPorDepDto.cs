namespace API.Dtos;
public class PaisPorDepDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre_pais { get; set; }

    //List<>
    public List<DepartamentoDto> ? Departamentos { get; set; }
        
}
