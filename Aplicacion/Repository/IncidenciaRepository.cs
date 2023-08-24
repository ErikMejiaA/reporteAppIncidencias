using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class IncidenciaRepository : GenericRepositoryA<Incidencia>, IIncidenciaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public IncidenciaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    public override async Task<IEnumerable<Incidencia>> GetAllAsync()
    {
        return await _context.Set<Incidencia>()
        .Include(p => p.EstadoIncidencias)
        .ToListAsync();
    }

    public override async Task<Incidencia> GetByIdAsync(int id)
    {
        return await _context.Set<Incidencia>()
        .Include(p => p.EstadoIncidencias)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Incidencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Incidencias as IQueryable<Incidencia>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_incidencia.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.EstadoIncidencias)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
    
}
