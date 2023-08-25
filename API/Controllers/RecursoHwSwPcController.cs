using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtner los departamento
[ApiVersion("1.1")] //obtener las listas
[ApiVersion("1.2")] //obtener paginacion, registros y buscador
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
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<RecursoHwSwXEquipoPCdTO>>> Get1A()
    {
        var recursos = await _UnitOfWork.RecursoHwSwPcs.GetAllAsync();
        return this.mapper.Map<List<RecursoHwSwXEquipoPCdTO>>(recursos);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<RecursoHwSwXEquipoPCdTO>>> Get1B([FromQuery] Params recursoParams)
    {
        var recursos = await _UnitOfWork.RecursoHwSwPcs.GetAllAsync(recursoParams.PageIndex, recursoParams.PageSize, recursoParams.Search);
        var lstrecursosDto = this.mapper.Map<List<RecursoHwSwXEquipoPCdTO>>(recursos.registros);

        return new Pager<RecursoHwSwXEquipoPCdTO>(lstrecursosDto, recursos.totalRegistros, recursoParams.PageIndex, recursoParams.PageSize, recursoParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecursoHwSwXEquipoPCdTO>> Get( int id)
    {
        var recursos = await _UnitOfWork.RecursoHwSwPcs.GetByIdAsync(id);

        if (recursos == null) {
            return NotFound();
        }

        return this.mapper.Map<RecursoHwSwXEquipoPCdTO>(recursos);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
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