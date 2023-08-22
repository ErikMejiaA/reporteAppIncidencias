using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class EstadoIncidenciaRepository : GenericRepositoryA<EstadoIncidencia>, IEstadoIncidenciaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public EstadoIncidenciaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
