using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los componentes de Hw, Sw del Equipo Pc
[ApiVersion("1.1")] //obtener las lista de equipos que contiene componentes 
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de componebtes o resucrsos del equipo Pc
public class RecursoHwSwPcController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public RecursoHwSwPcController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<RecursoHwSwPcDto>>> Get()
    {
        var recursos = await _UnitOfWork.RecursoHwSwPcs.GetAllAsync();
        return this.mapper.Map<List<RecursoHwSwPcDto>>(recursos);
    }

    //METODO GET (obtener todas las list)
    //[HttpGet]
    [HttpGet("Todo")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<RecursoHwSwXEquipoPcDto>>> Get1A()
    {
        var recursos = await _UnitOfWork.RecursoHwSwPcs.GetAllAsync();
        return this.mapper.Map<List<RecursoHwSwXEquipoPcDto>>(recursos);
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
    public async Task<ActionResult<Pager<RecursoHwSwXEquipoPcDto>>> Get1B([FromQuery] Params recursoParams)
    {
        var recursos = await _UnitOfWork.RecursoHwSwPcs.GetAllAsync(recursoParams.PageIndex, recursoParams.PageSize, recursoParams.Search);
        var lstrecursosDto = this.mapper.Map<List<RecursoHwSwXEquipoPcDto>>(recursos.registros);

        return new Pager<RecursoHwSwXEquipoPcDto>(lstrecursosDto, recursos.totalRegistros, recursoParams.PageIndex, recursoParams.PageSize, recursoParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecursoHwSwXEquipoPcDto>> Get( int id)
    {
        var recursos = await _UnitOfWork.RecursoHwSwPcs.GetByIdAsync(id);

        if (recursos == null) {
            return NotFound();
        }

        return this.mapper.Map<RecursoHwSwXEquipoPcDto>(recursos);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecursoHwSwPcDto>> Post(RecursoHwSwPcDto recursoHwSwPcDto)
    {
        var recurso = this.mapper.Map<RecursoHwSwPc>(recursoHwSwPcDto);
        _UnitOfWork.RecursoHwSwPcs.Add(recurso);
        await _UnitOfWork.SaveAsync();

        if (recurso == null) {
            return BadRequest();
        }

        return this.mapper.Map<RecursoHwSwPcDto>(recurso);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecursoHwSwPcDto>> Put(int id, [FromBody] RecursoHwSwPcDto recursoHwSwPcDto)
    {
        if (recursoHwSwPcDto == null) {
            return NotFound();
        }

        var recurso = this.mapper.Map<RecursoHwSwPc>(recursoHwSwPcDto);
        recurso.Id_codigo = id;
        _UnitOfWork.RecursoHwSwPcs.Update(recurso);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<RecursoHwSwPcDto>(recurso);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecursoHwSwPcDto>> Delete(int id)
    {
        var recurso = await _UnitOfWork.RecursoHwSwPcs.GetByIdAsync(id);
        
        if (recurso == null) {
            return NotFound();
        }

        _UnitOfWork.RecursoHwSwPcs.Remove(recurso);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}