namespace Dominio.Entities;
public class EstadoIncidencia : BaseEntityA
{
    public string ? Estado { get; set; }
    public string ? Descripcion { get; set; }

    //foranea
    public int Id_incidenciaFK { get; set; }

    //referencia 
    public Incidencia ? Incidencia { get; set; }
    
        
}
