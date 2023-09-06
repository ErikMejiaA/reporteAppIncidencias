using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener las ciudades 
[ApiVersion("1.1")] //obtener las personas que pertenecen a una ciudad
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de las ciudades
public class CiudadController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public CiudadController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<CiudadDto>>> Get()
    {
        var ciudades = await _UnitOfWork.Ciudades.GetAllAsync();
        return this.mapper.Map<List<CiudadDto>>(ciudades);
    }

    //METODO GET (obtener todas las personas que pertenecen a una ciudad)
    //[HttpGet]
    [HttpGet("Todo")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<CiudadPersonaDto>>> Get1A()
    {
        var ciudadPersonas = await _UnitOfWork.Ciudades.GetAllAsync();
        return this.mapper.Map<List<CiudadPersonaDto>>(ciudadPersonas);
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
    public async Task<ActionResult<Pager<CiudadPersonaDto>>> Get1B([FromQuery] Params ciudadParams)
    {
        var ciudadaPerson = await _UnitOfWork.Ciudades.GetAllAsync(ciudadParams.PageIndex, ciudadParams.PageSize, ciudadParams.Search);
        var lstCiudadPersonas = this.mapper.Map<List<CiudadPersonaDto>>(ciudadaPerson.registros);

        return new Pager<CiudadPersonaDto>(lstCiudadPersonas, ciudadaPerson.totalRegistros, ciudadParams.PageIndex, ciudadParams.PageSize, ciudadParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CiudadPersonaDto>> Get( int id)
    {
        var ciudadPersona = await _UnitOfWork.Ciudades.GetByIdAsync(id);

        if (ciudadPersona == null) {
            return NotFound();
        }

        return this.mapper.Map<CiudadPersonaDto>(ciudadPersona);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CiudadDto>> Post(CiudadDto ciudadDto)
    {
        var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
        _UnitOfWork.Ciudades.Add(ciudad);
        await _UnitOfWork.SaveAsync();

        if (ciudad == null) {
            return BadRequest();
        }

        return this.mapper.Map<CiudadDto>(ciudad);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody] CiudadDto ciudadDto)
    {
        if (ciudadDto == null) {
            return NotFound();
        }

        var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
        ciudad.Id_codigo = id;
        _UnitOfWork.Ciudades.Update(ciudad);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<CiudadDto>(ciudad);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CiudadDto>> Delete(int id)
    {
        var ciudad = await _UnitOfWork.Ciudades.GetByIdAsync(id);
        
        if (ciudad == null) {
            return NotFound();
        }

        _UnitOfWork.Ciudades.Remove(ciudad);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
