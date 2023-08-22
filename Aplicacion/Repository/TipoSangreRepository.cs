using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoSangreRepository : GenericRepositoryA<TipoSangre>, ITipoSangreInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoSangreRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
