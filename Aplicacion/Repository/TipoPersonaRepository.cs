using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoPersonaRepository : GenericRepositoryA<TipoPersona>, ITipoPersonaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoPersonaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
    {
        return await _context.Set<TipoPersona>()
        .Include(p => p.Personas)
        .ToListAsync();
    }

    public override async Task<TipoPersona> GetByIdAsync(int id)
    {
        return await _context.Set<TipoPersona>()
        .Include(p => p.Personas)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoPersona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoPersonas as IQueryable<TipoPersona>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_tipoPersona.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Personas)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    
}
