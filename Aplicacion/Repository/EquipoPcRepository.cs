using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class EquipoPcRepository : GenericRepositoryB<EquipoPc>, IEquipoPcInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public EquipoPcRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    public override async Task<IEnumerable<EquipoPc>> GetAllAsync()
    {
        return await _context.Set<EquipoPc>()
        .Include(p => p.EquipoPcRecursoHwSwPcs)
        .ToListAsync();
    }

    public override async Task<EquipoPc> GetByIdAsync(string id)
    {
        return await _context.Set<EquipoPc>()
        .Include(p => p.EquipoPcRecursoHwSwPcs)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<EquipoPc> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.EquipoPcs as IQueryable<EquipoPc>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_referenciaPc.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.EquipoPcRecursoHwSwPcs)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
    
}
