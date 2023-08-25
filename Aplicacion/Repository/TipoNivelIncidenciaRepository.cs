using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoNivelIncidenciaRepository : GenericRepositoryA<TipoNivelIncidencia>, ITipoNivelIncidenciaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoNivelIncidenciaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<TipoNivelIncidencia>> GetAllAsync()
    {
        return await _context.Set<TipoNivelIncidencia>()
        .Include(p => p.Incidencias)
        .ToListAsync();
    }
    public override async Task<TipoNivelIncidencia> GetByIdAsync(int id)
    {
        return await _context.Set<TipoNivelIncidencia>()
        .Include(p => p.Incidencias)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoNivelIncidencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoNivelIncidencias as IQueryable<TipoNivelIncidencia>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_tipoNivelIncidencia.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Incidencias)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

}
