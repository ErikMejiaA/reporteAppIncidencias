using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class EstadoIncidenciaRepository : GenericRepositoryA<EstadoIncidencia>, IEstadoIncidenciaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public EstadoIncidenciaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    public override async Task<(int totalRegistros, IEnumerable<EstadoIncidencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.EstadoIncidencias as IQueryable<EstadoIncidencia>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Estado.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
    
}
