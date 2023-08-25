using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class SalonRepository : GenericRepositoryB<Salon>, ISalonInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public SalonRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<Salon>> GetAllAsync()
    {
        return await _context.Set<Salon>()
        .Include(p => p.Incidencias)
        .Include(p => p.Puestos)
        .ToListAsync();
    }

    public override async Task<Salon> GetByIdAsync(string id)
    {
        return await _context.Set<Salon>()
        .Include(p => p.Incidencias)
        .Include(p => p.Puestos)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Salon> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Salones as IQueryable<Salon>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_salon.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Incidencias)
                                .Include(p => p.Puestos)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
}
