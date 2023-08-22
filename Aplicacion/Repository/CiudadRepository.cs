using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class CiudadRepository : GenericRepositoryA<Ciudad>, ICiudadInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public CiudadRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
}
