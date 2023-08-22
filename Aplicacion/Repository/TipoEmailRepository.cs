using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoEmailRepository : GenericRepositoryA<TipoEmail>, ITipoEmailInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoEmailRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
