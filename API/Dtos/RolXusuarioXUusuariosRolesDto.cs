namespace API.Dtos;
public class RolXusuarioXUusuariosRolesDto
{
    public int Id_codigo { get; set; }
    public string ? Nombre { get; set; }
    public string ? Descripcion { get; set; }

    //List<>
    public List<UsuarioDto> ? Usuarios { get; set; }
    public List<UsuariosRolesDto> ? UsuariosRoles { get; set; }
        
}
