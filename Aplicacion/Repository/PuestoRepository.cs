using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PuestoRepository : GenericRepositoryB<Puesto>, IPuestoInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public PuestoRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<Puesto>> GetAllAsync()
    {
        return await _context.Set<Puesto>()
        .Include(p => p.Incidencias)
        .ToListAsync();
    }

    public override async Task<Puesto> GetByIdAsync(string id)
    {
        return await _context.Set<Puesto>()
        .Include(p => p.Incidencias)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }
    
    public override async Task<(int totalRegistros, IEnumerable<Puesto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Puestos as IQueryable<Puesto>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_puesto.ToLower().Contains(search));
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
