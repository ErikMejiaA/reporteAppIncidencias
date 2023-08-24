using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class CiudadRepository : GenericRepositoryA<Ciudad>, ICiudadInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public CiudadRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Set<Ciudad>()
        .Include(p => p.Personas)
        .ToListAsync();
    }

    public override async Task<Ciudad> GetByIdAsync(int id)
    {
        return await _context.Set<Ciudad>()
        .Include(p => p.Personas)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Ciudad> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Ciudades as IQueryable<Ciudad>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_ciudad.ToLower().Contains(search));
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
