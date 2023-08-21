namespace Dominio.Entities;
public class AreaIncidencia : BaseEntityA
{
    public string ? Nombre_areaIncidencia { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    public ICollection<Incidencia> ? Incidencias { get; set; }
    public ICollection<Salon> ? Salones { get; set; }
        
}
