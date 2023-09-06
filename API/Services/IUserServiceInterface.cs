
using API.Dtos;
using Dominio.Entities;

namespace API.Services;
public interface IUserServiceInterface
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<DatosUsuarioDto> GetTokenAsync(LoginDto model);
    Task<string> AddRoleAsync(AddRoleDto model);
    Task<Usuario> EditarUsuarioAsync(Usuario model);
        
}
