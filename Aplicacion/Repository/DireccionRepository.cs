using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class DireccionRepository : GenericRepositoryA<Direccion>, IDireccionInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public DireccionRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    public override async Task<(int totalRegistros, IEnumerable<Direccion> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Direcciones as IQueryable<Direccion>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Calle.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
    
}
