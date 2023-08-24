using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class GeneroRepository : GenericRepositoryA<Genero>, IGeneroInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public GeneroRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    public override async Task<IEnumerable<Genero>> GetAllAsync()
    {
        return await _context.Set<Genero>()
        .Include(p => p.Personas)
        .ToListAsync();
    }

    public override async Task<Genero> GetByIdAsync(int id)
    {
        return await _context.Set<Genero>()
        .Include(p => p.Personas)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Genero> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Generos as IQueryable<Genero>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_genero.ToLower().Contains(search));
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
