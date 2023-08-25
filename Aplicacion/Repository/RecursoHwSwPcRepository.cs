using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
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

    public override async Task<IEnumerable<RecursoHwSwPc>> GetAllAsync()
    {
        return await _context.Set<RecursoHwSwPc>()
        .Include(p => p.EquipoPcRecursoHwSwPcs)
        .ToListAsync();
    }

    public override async Task<RecursoHwSwPc> GetByIdAsync(int id)
    {
        return await _context.Set<RecursoHwSwPc>()
        .Include(p => p.EquipoPcRecursoHwSwPcs)
        .FirstOrDefaultAsync(p => p.Id_codigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<RecursoHwSwPc> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.RecursoHwSwPcs as IQueryable<RecursoHwSwPc>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre_recursoHwSwPc.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(p => p.EquipoPcRecursoHwSwPcs)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }

}
