using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PaisRepository : GenericRepositoryA<Pais>, IPaisInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public PaisRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Set<Pais>()
        .Include(p => p.Departamentos)
        .ThenInclude(p => p.Ciudades)
        .ToListAsync();
    }

    public override async Task<Pais> GetByIdAsync(int id)
    {
        return await _context.Set<Pais>()
        .Include(p => p.Departamentos)
        .ThenInclude(p => p.Ciudades)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }
    
    public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Paises as IQueryable<Pais>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_pais.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Departamentos)
                                .ThenInclude(p => p.Ciudades)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
}
