using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class EquipoPcRepository : GenericRepositoryB<EquipoPc>, IEquipoPcInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public EquipoPcRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
