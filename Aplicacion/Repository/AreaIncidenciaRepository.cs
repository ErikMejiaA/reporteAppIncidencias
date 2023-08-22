using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class AreaIncidenciaRepository : GenericRepositoryA<AreaIncidencia>, IAreaIncidenciaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public AreaIncidenciaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
