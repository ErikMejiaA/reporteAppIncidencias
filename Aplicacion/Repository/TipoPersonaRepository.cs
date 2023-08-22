using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoPersonaRepository : GenericRepositoryA<TipoPersona>, ITipoPersonaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoPersonaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
