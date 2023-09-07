using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los Estados de la Incidencias
[ApiVersion("1.1")] //obtener las de incidencias en un estado
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de un estado
public class EstadoIncidenciaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public EstadoIncidenciaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones
    //METODO GET (obtener todos los registros de un estado)
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<EstadoIncidenciaDto>>> Get()
    {
        var estados = await _UnitOfWork.EstadoIncidencias.GetAllAsync();
        return this.mapper.Map<List<EstadoIncidenciaDto>>(estados);
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
    public async Task<ActionResult<Pager<EstadoIncidenciaDto>>> Get1B([FromQuery] Params estadoParams)
    {
        var estados = await _UnitOfWork.EstadoIncidencias.GetAllAsync(estadoParams.PageIndex, estadoParams.PageSize, estadoParams.Search);
        var lstEstadosDto = this.mapper.Map<List<EstadoIncidenciaDto>>(estados.registros);

        return new Pager<EstadoIncidenciaDto>(lstEstadosDto, estados.totalRegistros, estadoParams.PageIndex, estadoParams.PageSize, estadoParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoIncidenciaDto>> Get( int id)
    {
        var estado = await _UnitOfWork.EstadoIncidencias.GetByIdAsync(id);

        if (estado == null) {
            return NotFound();
        }

        return this.mapper.Map<EstadoIncidenciaDto>(estado);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoIncidenciaDto>> Post(EstadoIncidenciaDto estadoIncidenciaDto)
    {
        var estado = this.mapper.Map<EstadoIncidencia>(estadoIncidenciaDto);
        _UnitOfWork.EstadoIncidencias.Add(estado);
        await _UnitOfWork.SaveAsync();

        if (estado == null) {
            return BadRequest();
        }

        return this.mapper.Map<EstadoIncidenciaDto>(estado);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoIncidenciaDto>> Put(int id, [FromBody] EstadoIncidenciaDto estadoIncidenciaDto)
    {
        if (estadoIncidenciaDto == null) {
            return NotFound();
        }

        var estado = this.mapper.Map<EstadoIncidencia>(estadoIncidenciaDto);
        estado.Id_codigo = id;
        _UnitOfWork.EstadoIncidencias.Update(estado);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<EstadoIncidenciaDto>(estado);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoIncidenciaDto>> Delete(int id)
    {
        var estado = await _UnitOfWork.EstadoIncidencias.GetByIdAsync(id);
        
        if (estado == null) {
            return NotFound();
        }

        _UnitOfWork.EstadoIncidencias.Remove(estado);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
