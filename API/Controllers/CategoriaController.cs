using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;
public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public CategoriaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }
    //peticiones 
}
