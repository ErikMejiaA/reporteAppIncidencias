using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoNivelIncidenciaRepository : GenericRepositoryA<TipoNivelIncidencia>, ITipoNivelIncidenciaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public TipoNivelIncidenciaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
