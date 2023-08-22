using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaTelefonoMovilRepository : IPersonaTelefonoMovilInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public PersonaTelefonoMovilRepository(ReporteAppIncidenciasContext context)
    {
        _context = context;
    }

    public void Add(PersonaTelefonoMovil entity)
    {
        _context.Set<PersonaTelefonoMovil>().Add(entity);
    }

    public void AddRange(IEnumerable<PersonaTelefonoMovil> entities)
    {
        _context.Set<PersonaTelefonoMovil>().AddRange(entities);
    }

    public IEnumerable<PersonaTelefonoMovil> Find(Expression<Func<PersonaTelefonoMovil, bool>> expression)
    {
        return _context.Set<PersonaTelefonoMovil>().Where(expression);
    }

    public async Task<IEnumerable<PersonaTelefonoMovil>> GetAllAsync()
    {
        return await _context.Set<PersonaTelefonoMovil>().ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<PersonaTelefonoMovil> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<PersonaTelefonoMovil>().CountAsync();
        var registros = await _context.Set<PersonaTelefonoMovil>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageIndex)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<PersonaTelefonoMovil> GetByIdAsync(string idPerson, int idTipoTelMov)
    {
        return await _context.Set<PersonaTelefonoMovil>().FirstOrDefaultAsync(p => (p.Id_personaFK == idPerson && p.Id_tipoTelefonoMovilFK == idTipoTelMov));
    }

    public void Remove(PersonaTelefonoMovil entity)
    {
        _context.Set<PersonaTelefonoMovil>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<PersonaTelefonoMovil> entities)
    {
        _context.Set<PersonaTelefonoMovil>().RemoveRange(entities);
    }

    public void Update(PersonaTelefonoMovil entity)
    {
        _context.Set<PersonaTelefonoMovil>().Update(entity);
    }
}
