using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class UsuarioRepository : GenericRepositoryA<Usuario>, IUsuarioInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public UsuarioRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Usuario> GetByUsernameAsync(string username)
    {
        return await _context.Set<Usuario>()
                                    .Include(u => u.Roles)
                                    .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }

    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Set<Usuario>()
        .Include(p => p.Roles)
        .ToListAsync();
    }

    public override async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Set<Usuario>()
        .Include(p => p.Roles)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Usuario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Usuarios as IQueryable<Usuario>;

        if (!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(p => p.Username.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.Roles)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }
}
