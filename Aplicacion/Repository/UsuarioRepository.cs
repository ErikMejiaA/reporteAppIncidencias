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
}
