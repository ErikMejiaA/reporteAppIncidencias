using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPersonaEmailInterface
{
    Task<PersonaEmail> GetByIdAsync(string idPerson, int idTipoEmail);
    Task<IEnumerable<PersonaEmail>> GetAllAsync();
    IEnumerable<PersonaEmail> Find(Expression<Func<PersonaEmail, bool>> expression);
    Task<(int totalRegistros, IEnumerable<PersonaEmail> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(PersonaEmail entity);
    void AddRange(IEnumerable<PersonaEmail> entities);
    void Remove(PersonaEmail entity);
    void RemoveRange(IEnumerable<PersonaEmail> entities);
    void Update(PersonaEmail entity);        
}
