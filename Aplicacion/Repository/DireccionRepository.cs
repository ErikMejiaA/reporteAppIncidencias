using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class DireccionRepository : GenericRepositoryA<Direccion>, IDireccionInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public DireccionRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
