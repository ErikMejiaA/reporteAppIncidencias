using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class ArlRepository : GenericRepositoryA<Arl>, IArlInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public ArlRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
}
