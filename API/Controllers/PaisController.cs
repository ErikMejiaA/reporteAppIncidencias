using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //trae solo los paises
[ApiVersion("1.1")] //trae paises con sus Dep
[ApiVersion("1.2")] //obtiene paginacion y registros y busquedas de un Pais
public class PaisController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public PaisController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET (obtener todos los registros de Paises de la Db)
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<PaisDto>>> Get()
    {
        var paises = await _UnitOfWork.Paises.GetAllAsync();
        return this.mapper.Map<List<PaisDto>>(paises);
    }

    //METODO GET (obtener solo los Paises con sus Dep de la Db)
    //[HttpGet]
    [HttpGet("Todo")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<PaisPorDepDto>>> Get1A()
    {
        var paisesDep = await _UnitOfWork.Paises.GetAllAsync();
        return this.mapper.Map<List<PaisPorDepDto>>(paisesDep);
    }

    //METODO GET (obtener solo los paises y Dep con paginacion y registros y busquedas de la Db)
    //[HttpGet]
    [HttpGet("Pag")]
    [MapToApiVersion("1.2")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<PaisPorDepDto>>> Get1B([FromQuery] Params paisParams)
    {
        var paises = await _UnitOfWork.Paises.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);

        var lstPaisesDto = this.mapper.Map<List<PaisPorDepDto>>(paises.registros);

        return new Pager<PaisPorDepDto>(lstPaisesDto, paises.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad Paises con su Dep de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisPorDepDto>> Get( int id)
    {
        var paisDep = await _UnitOfWork.Paises.GetByIdAsync(id);

        if (paisDep == null) {
            return NotFound();
        }

        return this.mapper.Map<PaisPorDepDto>(paisDep);
    }

    //METODO POST (para enviar ragistros a la entidad Paises de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Post(PaisDto paisDto)
    {
        var pais = this.mapper.Map<Pais>(paisDto);
        _UnitOfWork.Paises.Add(pais);
        await _UnitOfWork.SaveAsync();

        if (pais == null) {
            return BadRequest();
        }

        return this.mapper.Map<PaisDto>(pais);
    }

    //METODO PUT (editar un registro de la entidad Pais de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Put(int id, [FromBody] PaisDto paisDto)
    {
        if (paisDto == null) {
            return NotFound();
        }

        var pais = this.mapper.Map<Pais>(paisDto);
        pais.Id_codigo = id;
        _UnitOfWork.Paises.Update(pais);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<PaisDto>(pais);        

    }

    //METODO DELETE (Eliminar un registro de la entidad Pais de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Delete(int id)
    {
        var pais = await _UnitOfWork.Paises.GetByIdAsync(id);
        
        if (pais == null) {
            return NotFound();
        }

        _UnitOfWork.Paises.Remove(pais);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
