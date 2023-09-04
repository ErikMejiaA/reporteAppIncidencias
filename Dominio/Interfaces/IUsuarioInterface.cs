
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IUsuarioInterface : IGenericInterfaceA<Usuario>
{
    Task<Usuario> GetByUsernameAsync(string username);
        
}
