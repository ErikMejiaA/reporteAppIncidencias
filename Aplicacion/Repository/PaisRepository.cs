using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PaisRepository : GenericRepositoryA<Pais>, IPaisInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public PaisRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)

    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Set<Pais>()
        .Include(p => p.Departamentos)
        .ToListAsync();
    }
    
}
