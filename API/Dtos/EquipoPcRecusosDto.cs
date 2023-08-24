namespace API.Dtos;
public class EquipoPcRecusosDto
{
    public string ? Id_codigo { get; set; }
    public string ? Nombre_referenciaPc { get; set; }
    public string ? Estado { get; set; }
    public string ? Marca { get; set; }
    public string ? Descripcion { get; set; }

    //List<>
    public List<EquipoPcRecursoHwSwPcDto> ? EquipoPcRecursoHwSwPcs { get; set; }
        
}
