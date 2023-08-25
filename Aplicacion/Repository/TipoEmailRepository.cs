using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoEmailRepository : GenericRepositoryA<TipoEmail>, ITipoEmailInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoEmailRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<TipoEmail>> GetAllAsync()
    {
        return await _context.Set<TipoEmail>()
        .Include(p => p.PersonaEmails)
        .ToListAsync();
    }

    public override async Task<TipoEmail> GetByIdAsync(int id)
    {
        return await _context.Set<TipoEmail>()
        .Include(p => p.PersonaEmails)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoEmail> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoEmails as IQueryable<TipoEmail>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_tipoEmail.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.PersonaEmails)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
    
}
