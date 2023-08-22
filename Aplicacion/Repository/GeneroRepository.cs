using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class GeneroRepository : GenericRepositoryA<Genero>, IGeneroInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public GeneroRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
}
