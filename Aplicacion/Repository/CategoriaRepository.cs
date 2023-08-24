using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class CategoriaRepository : GenericRepositoryA<Categoria>, ICategoriaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public CategoriaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _context.Set<Categoria>()
        .Include(p => p.Incidencias)
        .Include(p => p.RecursoHwSwPcs)
        .ToListAsync();
    }

    public override async Task<Categoria> GetByIdAsync(int id)
    {
        return await _context.Set<Categoria>()
        .Include(p => p.Incidencias)
        .Include(p => p.RecursoHwSwPcs)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Categoria> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Categorias as IQueryable<Categoria>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_categoria.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Incidencias)
                                .Include(p => p.RecursoHwSwPcs)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

}
