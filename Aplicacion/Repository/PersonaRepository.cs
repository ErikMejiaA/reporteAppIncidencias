using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class PersonaRepository : GenericRepositoryB<Persona>, IPersonaInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public PersonaRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
    
}
