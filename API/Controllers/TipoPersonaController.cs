using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtner los tipos de cargos de la persona
[ApiVersion("1.1")] //obtener las personas por el tipo de cargo 
[ApiVersion("1.2")] //obtener paginacion, registros y buscador por tipo de persona o cargo
public class TipoPersonaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public TipoPersonaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones 
    //METODO GET (obtener todos los registros)
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TipoPersonaDto>>> Get()
    {
        var tipoPersonas = await _UnitOfWork.TipoPersonas.GetAllAsync();
        return this.mapper.Map<List<TipoPersonaDto>>(tipoPersonas);
    }

    //METODO GET (obtener todas las list)
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TipoPersonaXpersonaDto>>> Get1A()
    {
        var tipoPersonas = await _UnitOfWork.TipoPersonas.GetAllAsync();
        return this.mapper.Map<List<TipoPersonaXpersonaDto>>(tipoPersonas);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<TipoPersonaXpersonaDto>>> Get1B([FromQuery] Params personaParams)
    {
        var tipoPersonas = await _UnitOfWork.TipoPersonas.GetAllAsync(personaParams.PageIndex, personaParams.PageSize, personaParams.Search);

        var lstTipoPersonaDto = this.mapper.Map<List<TipoPersonaXpersonaDto>>(tipoPersonas.registros);

        return new Pager<TipoPersonaXpersonaDto>(lstTipoPersonaDto, tipoPersonas.totalRegistros, personaParams.PageIndex, personaParams.PageSize, personaParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersonaXpersonaDto>> Get( int id)
    {
        var tipoPersonas = await _UnitOfWork.TipoPersonas.GetByIdAsync(id);

        if (tipoPersonas == null) {
            return NotFound();
        }

        return this.mapper.Map<TipoPersonaXpersonaDto>(tipoPersonas);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersonaDto>> Post(TipoPersonaDto tipoPersonaDto)
    {
        var tipoPersona = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        _UnitOfWork.TipoPersonas.Add(tipoPersona);
        await _UnitOfWork.SaveAsync();

        if (tipoPersona == null) {
            return BadRequest();
        }

        return this.mapper.Map<TipoPersonaDto>(tipoPersona);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto tipoPersonaDto)
    {
        if (tipoPersonaDto == null) {
            return NotFound();
        }

        var tipoPersona = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        tipoPersona.Id_codigo = id;
        _UnitOfWork.TipoPersonas.Update(tipoPersona);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<TipoPersonaDto>(tipoPersona);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersonaDto>> Delete(int id)
    {
        var tipoPersona = await _UnitOfWork.TipoPersonas.GetByIdAsync(id);
        
        if (tipoPersona == null) {
            return NotFound();
        }

        _UnitOfWork.TipoPersonas.Remove(tipoPersona);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
