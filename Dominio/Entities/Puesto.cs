namespace Dominio.Entities;
public class Puesto : BaseEntityB
{
    public string ? Nombre_puesto { get; set; }
    public string ? Estado { get; set; }

    //Foraneas
    public string ? Id_salonFK { get; set; }
    public string ? Id_equipoFK  { get; set; }

    //ICollection 
    public ICollection<Incidencia> ? Incidencias { get; set; }

    //referencia 
    public Salon ? Salon { get; set; }
    public EquipoPc ? EquipoPc  { get; set; }
    
}
