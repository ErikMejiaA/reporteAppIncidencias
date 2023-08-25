using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoTelefonoMovilRepository : GenericRepositoryA<TipoTelefonoMovil>, ITipoTelefonoMovilInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoTelefonoMovilRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<TipoTelefonoMovil>> GetAllAsync()
    {
        return await _context.Set<TipoTelefonoMovil>()
        .Include(p => p.PersonaTelefonoMoviles)
        .ToListAsync();
    }

    public override async Task<TipoTelefonoMovil> GetByIdAsync(int id)
    {
        return await _context.Set<TipoTelefonoMovil>()
        .Include(p => p.PersonaTelefonoMoviles)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoTelefonoMovil> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoTelefonoMoviles as IQueryable<TipoTelefonoMovil>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_tipoTelMov.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.PersonaTelefonoMoviles)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

}
