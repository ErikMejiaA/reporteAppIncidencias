using AutoMapper;
using Dominio.Interfaces;

namespace API.Controllers;
public class EquipoPcRecursoHwSwPcController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public EquipoPcRecursoHwSwPcController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones
}
