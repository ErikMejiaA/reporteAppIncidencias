using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class AreaIncidenciaRepository : GenericRepositoryA<AreaIncidencia>, IAreaIncidenciaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public AreaIncidenciaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
    public override async Task<IEnumerable<AreaIncidencia>> GetAllAsync()
    {

        return await _context.Set<AreaIncidencia>()
        .Include(p => p.Incidencias)
        .Include(p => p.Salones)
        .ToListAsync();
    }

    public override async Task<AreaIncidencia> GetByIdAsync(int id)
    {
        return await _context.Set<AreaIncidencia>()
        .Include(p => p.Incidencias)
        .Include(p => p.Salones)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<AreaIncidencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.AreaIncidencias as IQueryable<AreaIncidencia>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_areaIncidencia.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Incidencias)
                                .Include(p => p.Salones)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

}
