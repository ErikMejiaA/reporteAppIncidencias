namespace Dominio.Entities;
public class PersonaEmail
{
    public string ? Email { get; set; }

    //foraneas
    public string ? Id_personaFK { get; set; }
    public int Id_tipoEmailFK { get; set; }

    //referencia 
    public Persona ? Persona { get; set; }
    public TipoEmail ? TipoEmail { get; set; }
    
        
}
