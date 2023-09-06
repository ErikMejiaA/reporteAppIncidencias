
namespace API.Dtos;
public class UsuarioDto
{
    public int Id_codigo { get; set; }
    public string ? Username { get; set; }
    public string ? Email { get; set; }
    public string ? Password { get; set; }

    //public List<RolDto> ? Roles { get; set; }
    //public List<UsuariosRolesDto> ? UsuariosRoles { get; set; }
}
