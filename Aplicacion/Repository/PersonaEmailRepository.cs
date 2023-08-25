using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaEmailRepository : IPersonaEmailInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public PersonaEmailRepository(ReporteAppIncidenciasContext context)
    {
        _context = context;
    }

    public void Add(PersonaEmail entity)
    {
        _context.Set<PersonaEmail>().Add(entity);
    }

    public void AddRange(IEnumerable<PersonaEmail> entities)
    {
        _context.Set<PersonaEmail>().AddRange(entities);
    }

    public IEnumerable<PersonaEmail> Find(Expression<Func<PersonaEmail, bool>> expression)
    {
        return _context.Set<PersonaEmail>().Where(expression);
    }

    public async Task<IEnumerable<PersonaEmail>> GetAllAsync()
    {
        return await _context.Set<PersonaEmail>().ToListAsync();
    }

    /*public async Task<(int totalRegistros, IEnumerable<PersonaEmail> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<PersonaEmail>().CountAsync();
        var registros = await _context.Set<PersonaEmail>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageIndex)
            .ToListAsync();

        return (totalRegistros, registros);
    }*/
    public async Task<(int totalRegistros, IEnumerable<PersonaEmail> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {

        var query = _context.PersonaEmails as IQueryable<PersonaEmail>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id_personaFK.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();

        var registros = await query
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageIndex)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<PersonaEmail> GetByIdAsync(string idPerson, int idTipoEmail)
    {
        return await _context.Set<PersonaEmail>().FirstOrDefaultAsync(p => (p.Id_personaFK == idPerson && p.Id_tipoEmailFK == idTipoEmail));
    }
    
    public void Remove(PersonaEmail entity)
    {
        _context.Set<PersonaEmail>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<PersonaEmail> entities)
    {
        _context.Set<PersonaEmail>().RemoveRange(entities);
    }

    public void Update(PersonaEmail entity)
    {
        _context.Set<PersonaEmail>().Update(entity);
    }
}
