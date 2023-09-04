namespace Dominio.Entities;
public class Rol : BaseEntityA
{
    public string ? Nombre { get; set; }
    public string ? Descripcion { get; set; }

    //ICollection<>
    //public ICollection<Persona> ? Personas { get; set; }
    public ICollection<Usuario> ? Usuarios { get; set; }
    public ICollection<UsuariosRoles> ? UsuariosRoles { get; set; }
        
}
