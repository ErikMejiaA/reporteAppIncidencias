namespace Dominio.Entities;
public class Salon : BaseEntityB
{
    public string ? Nombre_salon { get; set; }
    public int Capasidad { get; set; }
    public string ? Descripcion { get; set; }

    //foranea 
    public int Id_areaIncidenciaFK { get; set; }

    //ICollection<>
    public ICollection<Incidencia> ? Incidencias { get; set; }
    public ICollection<Puesto> ? Puestos { get; set; }

    //referencia 
    public AreaIncidencia ? AreaIncidencia { get; set; }
        
}
