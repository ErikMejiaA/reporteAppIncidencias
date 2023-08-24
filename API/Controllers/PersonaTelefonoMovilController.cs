using AutoMapper;
using Dominio.Interfaces;

namespace API.Controllers;
public class PersonaTelefonoMovilController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public PersonaTelefonoMovilController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones 
}
