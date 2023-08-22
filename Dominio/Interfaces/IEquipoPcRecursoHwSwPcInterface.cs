using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IEquipoPcRecursoHwSwPcInterface
{
    Task<EquipoPcRecursoHwSwPc> GetByIdAsync(string idEquiPc, int idRecurso);
    Task<IEnumerable<EquipoPcRecursoHwSwPc>> GetAllAsync();
    IEnumerable<EquipoPcRecursoHwSwPc> Find(Expression<Func<EquipoPcRecursoHwSwPc, bool>> expression);
    Task<(int totalRegistros, IEnumerable<EquipoPcRecursoHwSwPc> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(EquipoPcRecursoHwSwPc entity);
    void AddRange(IEnumerable<EquipoPcRecursoHwSwPc> entities);
    void Remove(EquipoPcRecursoHwSwPc entity);
    void RemoveRange(IEnumerable<EquipoPcRecursoHwSwPc> entities);
    void Update(EquipoPcRecursoHwSwPc entity);       
}
