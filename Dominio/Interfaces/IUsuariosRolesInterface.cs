using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IUsuariosRolesInterface
{
    Task<UsuariosRoles> GetByIdAsync(int idUsua, int idRol);
    Task<IEnumerable<UsuariosRoles>> GetAllAsync();
    IEnumerable<UsuariosRoles> Find(Expression<Func<UsuariosRoles, bool>> expression);
    Task<(int totalRegistros, IEnumerable<UsuariosRoles> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(UsuariosRoles entity);
    void AddRange(IEnumerable<UsuariosRoles> entities);
    void Remove(UsuariosRoles entity);
    void RemoveRange(IEnumerable<UsuariosRoles> entities);
    void Update(UsuariosRoles entity);        
}