using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener solo las areas de incidencias
[ApiVersion("1.1")] //obtener las incidencias y los salones del area
[ApiVersion("1.2")] //obtener paginacion, registros y buscador
public class AreaIncidenciaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public AreaIncidenciaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones o EndPoint
    //METODO GET (obtener todos los registros)
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<AreaIncidenciaDto>>> Get()
    {
        var areas = await _UnitOfWork.AreaIncidencias.GetAllAsync();
        return this.mapper.Map<List<AreaIncidenciaDto>>(areas);
    }

    //METODO GET (obtener todos los registos de incidencias y salones en las areas)
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<AreaIncidenciaSalonDto>>> Get1A()
    {
        var areasSalonesInc = await _UnitOfWork.AreaIncidencias.GetAllAsync();
        return this.mapper.Map<List<AreaIncidenciaSalonDto>>(areasSalonesInc);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<AreaIncidenciaSalonDto>>> Get1B([FromQuery] Params areaParams)
    {
        var areas = await _UnitOfWork.AreaIncidencias.GetAllAsync(areaParams.PageIndex, areaParams.PageSize, areaParams.Search);
        var lstAreasIncSaDto = this.mapper.Map<List<AreaIncidenciaSalonDto>>(areas.registros);

        return new Pager<AreaIncidenciaSalonDto>(lstAreasIncSaDto, areas.totalRegistros, areaParams.PageIndex, areaParams.PageSize, areaParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AreaIncidenciaSalonDto>> Get( int id)
    {
        var areasIncSa = await _UnitOfWork.AreaIncidencias.GetByIdAsync(id);

        if (areasIncSa == null) {
            return NotFound();
        }

        return this.mapper.Map<AreaIncidenciaSalonDto>(areasIncSa);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AreaIncidenciaDto>> Post(AreaIncidenciaDto areaIncidenciaDto)
    {
        var area = this.mapper.Map<AreaIncidencia>(areaIncidenciaDto);
        _UnitOfWork.AreaIncidencias.Add(area);
        await _UnitOfWork.SaveAsync();

        if (area == null) {
            return BadRequest();
        }

        return this.mapper.Map<AreaIncidenciaDto>(area);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AreaIncidenciaDto>> Put(int id, [FromBody] AreaIncidenciaDto areaIncidenciaDto)
    {
        if (areaIncidenciaDto == null) {
            return NotFound();
        }

        var areaInc = this.mapper.Map<AreaIncidencia>(areaIncidenciaDto);
        areaInc.Id_codigo = id;
        _UnitOfWork.AreaIncidencias.Update(areaInc);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<AreaIncidenciaDto>(areaInc);        

    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AreaIncidenciaDto>> Delete(int id)
    {
        var areaInc = await _UnitOfWork.AreaIncidencias.GetByIdAsync(id);
        
        if (areaInc == null) {
            return NotFound();
        }

        _UnitOfWork.AreaIncidencias.Remove(areaInc);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
