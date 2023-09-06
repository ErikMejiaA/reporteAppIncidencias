using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener las incidencias 
[ApiVersion("1.1")] //obtener los estados de una incidencia
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de una incidencia
public class IncidenciaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public IncidenciaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<IncidenciaDto>>> Get()
    {
        var incidencias = await _UnitOfWork.Incidencias.GetAllAsync();
        return this.mapper.Map<List<IncidenciaDto>>(incidencias);
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
    public async Task<ActionResult<List<IncidenciaPorEstadoDto>>> Get1A()
    {
        var incidenciasE = await _UnitOfWork.Incidencias.GetAllAsync();
        return this.mapper.Map<List<IncidenciaPorEstadoDto>>(incidenciasE);
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
    public async Task<ActionResult<Pager<IncidenciaPorEstadoDto>>> Get1B([FromQuery] Params incidenParams)
    {
        var incidencias = await _UnitOfWork.Incidencias.GetAllAsync(incidenParams.PageIndex, incidenParams.PageSize, incidenParams.Search);
        var lstIncidenciaDto = this.mapper.Map<List<IncidenciaPorEstadoDto>>(incidencias.registros);

        return new Pager<IncidenciaPorEstadoDto>(lstIncidenciaDto, incidencias.totalRegistros, incidenParams.PageIndex, incidenParams.PageSize, incidenParams.Search);
    }

     //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IncidenciaPorEstadoDto>> Get( int id)
    {
        var incidencias = await _UnitOfWork.Incidencias.GetByIdAsync(id);

        if (incidencias == null) {
            return NotFound();
        }

        return this.mapper.Map<IncidenciaPorEstadoDto>(incidencias);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IncidenciaDto>> Post(IncidenciaDto incidenciaDto)
    {
        var incidencia = this.mapper.Map<Incidencia>(incidenciaDto);
        _UnitOfWork.Incidencias.Add(incidencia);
        await _UnitOfWork.SaveAsync();

        if (incidencia == null) {
            return BadRequest();
        }

        return this.mapper.Map<IncidenciaDto>(incidencia);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IncidenciaDto>> Put(int id, [FromBody] IncidenciaDto incidenciaDto)
    {
        if (incidenciaDto == null) {
            return NotFound();
        }

        var incidencia = this.mapper.Map<Incidencia>(incidenciaDto);
        incidencia.Id_codigo = id;
        _UnitOfWork.Incidencias.Update(incidencia);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<IncidenciaDto>(incidencia);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IncidenciaDto>> Delete(int id)
    {
        var incidencia = await _UnitOfWork.Incidencias.GetByIdAsync(id);
        
        if (incidencia == null) {
            return NotFound();
        }

        _UnitOfWork.Incidencias.Remove(incidencia);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
