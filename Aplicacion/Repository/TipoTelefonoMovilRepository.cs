using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoTelefonoMovilRepository : GenericRepositoryA<TipoTelefonoMovil>, ITipoTelefonoMovilInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoTelefonoMovilRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
