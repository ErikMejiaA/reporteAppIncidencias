using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class PaisController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;

    public PaisController(IUnitOfWorkInterface UnitOfWork)
    {
        _UnitOfWork = UnitOfWork;
    }

    //METODO GET (obtener datos de la Db)
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var paises = await _UnitOfWork.Paises.GetAllAsync();
        return Ok(paises);
    }
}
