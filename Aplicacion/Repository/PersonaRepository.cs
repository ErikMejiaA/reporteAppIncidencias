using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepositoryB<Persona>, IPersonaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public PersonaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Set<Persona>()
        .Include(p => p.Incidencias)
        .Include(p => p.Direcciones)
        .Include(p => p.PersonaTelefonoMoviles)
        .Include(p => p.PersonaEmails)
        .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(string id)
    {
        return await _context.Set<Persona>()
        .Include(p => p.Incidencias)
        .Include(p => p.Direcciones)
        .Include(p => p.PersonaTelefonoMoviles)
        .Include(p => p.PersonaEmails)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Persona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Personas as IQueryable<Persona>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Incidencias)
                                .Include(p => p.Direcciones)
                                .Include(p => p.PersonaTelefonoMoviles)
                                .Include(p => p.PersonaEmails)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

}
