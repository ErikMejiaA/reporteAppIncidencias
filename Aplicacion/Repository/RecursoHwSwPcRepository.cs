using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class RecursoHwSwPcRepository : GenericRepositoryA<RecursoHwSwPc>, IRecursoHwSwPcInterface
{
    private readonly ReporteAppIncidenciasContext _context;

    public RecursoHwSwPcRepository(ReporteAppIncidenciasContext context) : base(context)
    {
        _context = context;
    }
    //aqui van otros tipos de metodos a implementar (override  sobre escribir funciones)
}
