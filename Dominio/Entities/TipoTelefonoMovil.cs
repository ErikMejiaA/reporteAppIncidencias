namespace Dominio.Entities;
public class TipoTelefonoMovil : BaseEntityA
{
    public string ? Nombre_tipoTelMov { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection
    public ICollection<PersonaTelefonoMovil> ? PersonaTelefonoMoviles { get; set; }
}
