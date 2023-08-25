using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class EquipoPcRecursoHwSwPcRepository : IEquipoPcRecursoHwSwPcInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public EquipoPcRecursoHwSwPcRepository(ReporteAppIncidenciasContext context)
    {
        _context = context;
    }

    public void Add(EquipoPcRecursoHwSwPc entity)
    {
        _context.Set<EquipoPcRecursoHwSwPc>().Add(entity);
    }

    public void AddRange(IEnumerable<EquipoPcRecursoHwSwPc> entities)
    {
        _context.Set<EquipoPcRecursoHwSwPc>().AddRange(entities);
    }

    public IEnumerable<EquipoPcRecursoHwSwPc> Find(Expression<Func<EquipoPcRecursoHwSwPc, bool>> expression)
    {
        return _context.Set<EquipoPcRecursoHwSwPc>().Where(expression);
    }

    public async Task<IEnumerable<EquipoPcRecursoHwSwPc>> GetAllAsync()
    {
        return await _context.Set<EquipoPcRecursoHwSwPc>().ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<EquipoPcRecursoHwSwPc> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.EquipoPcRecursoHwSwPcs as IQueryable<EquipoPcRecursoHwSwPc>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id_equipoFK.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();

        var registros = await query
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageIndex)
                            .ToListAsync();
            
        return (totalRegistros, registros);
    }
    
    /*public virtual async Task<(int totalRegistros, IEnumerable<EquipoPcRecursoHwSwPc> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<EquipoPcRecursoHwSwPc>().CountAsync();
        var registros = await _context.Set<EquipoPcRecursoHwSwPc>()
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

        return (totalRegistros, registros);
    }*/

    public async Task<EquipoPcRecursoHwSwPc> GetByIdAsync(string idEquiPc, int idRecurso)
    {
        return await _context.Set<EquipoPcRecursoHwSwPc>().FirstOrDefaultAsync(p => (p.Id_equipoFK == idEquiPc && p.Id_recursoHwSwPcFK == idRecurso));
    }

    public void Remove(EquipoPcRecursoHwSwPc entity)
    {
        _context.Set<EquipoPcRecursoHwSwPc>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<EquipoPcRecursoHwSwPc> entities)
    {
        _context.Set<EquipoPcRecursoHwSwPc>().RemoveRange(entities);
    }

    public void Update(EquipoPcRecursoHwSwPc entity)
    {
        _context.Set<EquipoPcRecursoHwSwPc>().Update(entity);
    }
    
}
