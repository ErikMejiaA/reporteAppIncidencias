namespace Dominio.Entities;
public class EquipoPcRecursoHwSwPc
{
    //foraneas 
    public string ? Id_equipoFK { get; set; }
    public int Id_recursoHwSwPcFK { get; set; }

    //referencia
    public EquipoPc ? EquipoPc { get; set; }
    public RecursoHwSwPc ? RecursoHwSwPc { get; set; }
    
}
