using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class PuestoRepository : GenericRepositoryB<Puesto>, IPuestoInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public PuestoRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
