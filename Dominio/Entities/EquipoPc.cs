namespace Dominio.Entities;
public class EquipoPc : BaseEntityB
{
    public string ? Nombre_referenciaPc { get; set; }
    public string ? Estado { get; set; }
    public string ? Marca { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    public ICollection<EquipoPcRecursoHwSwPc> ? EquipoPcRecursoHwSwPcs { get; set; }

    //referencia 
    public Puesto ? Puesto { get; set; }
      
}
