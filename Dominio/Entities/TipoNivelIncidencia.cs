namespace Dominio.Entities;

public class TipoNivelIncidencia : BaseEntityA
{
    public string ? Nombre_tipoNivelIncidencia { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    public ICollection<Incidencia> ? Incidencias { get; set; } 
        
}
