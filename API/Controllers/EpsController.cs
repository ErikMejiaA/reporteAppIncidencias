using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener las Eps
[ApiVersion("1.1")] //obtener las lista de personas que pertenecen a una eps
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de la eps
public class EpsController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public EpsController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones 
    //METODO GET (obtener todos los registros)
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<EpsDto>>> Get()
    {
        var eps = await _UnitOfWork.Eps.GetAllAsync();
        return this.mapper.Map<List<EpsDto>>(eps);
    }

    //METODO GET (obtener todas las personas de una eps)
    //[HttpGet]
    [HttpGet("Todo")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<EpsPersonaDto>>> Get1A()
    {
        var epsPersonas = await _UnitOfWork.Eps.GetAllAsync();
        return this.mapper.Map<List<EpsPersonaDto>>(epsPersonas);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    //[HttpGet]
    [HttpGet("Pag")]
    [Authorize]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<EpsPersonaDto>>> Get1B([FromQuery] Params epsParams)
    {
        var epsPersonas = await _UnitOfWork.Eps.GetAllAsync(epsParams.PageIndex, epsParams.PageSize, epsParams.Search);
        var lstEpsPersonaDto = this.mapper.Map<List<EpsPersonaDto>>(epsPersonas.registros);

        return new Pager<EpsPersonaDto>(lstEpsPersonaDto, epsPersonas.totalRegistros, epsParams.PageIndex, epsParams.PageSize, epsParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EpsPersonaDto>> Get( int id)
    {
        var epsPersona = await _UnitOfWork.Eps.GetByIdAsync(id);

        if (epsPersona == null) {
            return NotFound();
        }

        return this.mapper.Map<EpsPersonaDto>(epsPersona);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EpsDto>> Post(EpsDto epsDto)
    {
        var eps = this.mapper.Map<Eps>(epsDto);
        _UnitOfWork.Eps.Add(eps);
        await _UnitOfWork.SaveAsync();

        if (eps == null) {
            return BadRequest();
        }

        return this.mapper.Map<EpsDto>(eps);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EpsDto>> Put(int id, [FromBody] EpsDto epsDto)
    {
        if (epsDto == null) {
            return NotFound();
        }

        var eps = this.mapper.Map<Eps>(epsDto);
        eps.Id_codigo = id;
        _UnitOfWork.Eps.Update(eps);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<EpsDto>(eps);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EpsDto>> Delete(int id)
    {
        var eps = await _UnitOfWork.Eps.GetByIdAsync(id);
        
        if (eps == null) {
            return NotFound();
        }

        _UnitOfWork.Eps.Remove(eps);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
    
}
