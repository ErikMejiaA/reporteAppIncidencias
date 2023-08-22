using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class IncidenciaRepository : GenericRepositoryA<Incidencia>, IIncidenciaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public IncidenciaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
