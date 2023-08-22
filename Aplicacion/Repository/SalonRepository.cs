using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class SalonRepository : GenericRepositoryB<Salon>, ISalonInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public SalonRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
