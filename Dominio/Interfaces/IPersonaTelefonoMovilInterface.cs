using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPersonaTelefonoMovilInterface
{
    Task<PersonaTelefonoMovil> GetByIdAsync(string idPerson, int idTipoTelMov);
    Task<IEnumerable<PersonaTelefonoMovil>> GetAllAsync();
    IEnumerable<PersonaTelefonoMovil> Find(Expression<Func<PersonaTelefonoMovil, bool>> expression);
    Task<(int totalRegistros, IEnumerable<PersonaTelefonoMovil> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(PersonaTelefonoMovil entity);
    void AddRange(IEnumerable<PersonaTelefonoMovil> entities);
    void Remove(PersonaTelefonoMovil entity);
    void RemoveRange(IEnumerable<PersonaTelefonoMovil> entities);
    void Update(PersonaTelefonoMovil entity);
}
