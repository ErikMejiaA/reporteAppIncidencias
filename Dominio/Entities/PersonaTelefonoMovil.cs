namespace Dominio.Entities; 
public class PersonaTelefonoMovil
{
    public string ? Numero_telefonoMovil { get; set; }

    //foranaes
    public string ? Id_personaFK { get; set; }
    public int Id_tipoTelefonoMovilFK { get; set; }

    //referencia
    public Persona ? Persona { get; set; }
    public TipoTelefonoMovil ? TipoTelefonoMovil { get; set; }
    
}
