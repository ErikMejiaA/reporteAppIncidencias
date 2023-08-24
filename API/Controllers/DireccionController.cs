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
public class DireccionController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public DireccionController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<DireccionDto>>> Get()
    {
        var direcciones = await _UnitOfWork.Departamentos.GetAllAsync();
        return this.mapper.Map<List<DireccionDto>>(direcciones);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<DireccionDto>>> Get1B([FromQuery] Params direccParams)
    {
        var direccion = await _UnitOfWork.Direcciones.GetAllAsync(direccParams.PageIndex, direccParams.PageSize, direccParams.Search);
        var lstDireccionDto = this.mapper.Map<List<DireccionDto>>(direccion.registros);

        return new Pager<DireccionDto>(lstDireccionDto, direccion.totalRegistros, direccParams.PageIndex, direccParams.PageSize, direccParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DireccionDto>> Get( int id)
    {
        var direccion = await _UnitOfWork.Direcciones.GetByIdAsync(id);

        if (direccion == null) {
            return NotFound();
        }

        return this.mapper.Map<DireccionDto>(direccion);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DireccionDto>> Post(DireccionDto direccionDto)
    {
        var direccion = this.mapper.Map<Direccion>(direccionDto);
        _UnitOfWork.Direcciones.Add(direccion);
        await _UnitOfWork.SaveAsync();

        if (direccion == null) {
            return BadRequest();
        }

        return this.mapper.Map<DireccionDto>(direccion);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DireccionDto>> Put(int id, [FromBody] DireccionDto direccionDto)
    {
        if (direccionDto == null) {
            return NotFound();
        }

        var direccion = this.mapper.Map<Direccion>(direccionDto);
        direccion.Id_codigo = id;
        _UnitOfWork.Direcciones.Update(direccion);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<DireccionDto>(direccion);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DireccionDto>> Delete(int id)
    {
        var direccion = await _UnitOfWork.Direcciones.GetByIdAsync(id);
        
        if (direccion == null) {
            return NotFound();
        }

        _UnitOfWork.Direcciones.Remove(direccion);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
    
}
