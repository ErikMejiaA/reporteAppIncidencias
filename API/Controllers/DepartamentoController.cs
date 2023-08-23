using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;
public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public DepartamentoController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones 
}
