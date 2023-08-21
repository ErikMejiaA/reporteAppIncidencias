namespace Dominio.Entities;
public class TipoEmail : BaseEntityA
{
    public string ? Nombre_tipoEmail { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    public ICollection<PersonaEmail> ? PersonaEmails { get; set; }

}
