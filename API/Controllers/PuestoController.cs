using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los puesto que hay dentro del salon
[ApiVersion("1.1")] //obtener las listas de incidencias presentes en el puesto
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de un puesto
public class PuestoController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public PuestoController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<PuestoDto>>> Get()
    {
        var puestos = await _UnitOfWork.Puestos.GetAllAsync();
        return this.mapper.Map<List<PuestoDto>>(puestos);
    }

    //METODO GET (obtener todas las incidencias de los puestos)
    //[HttpGet]
    [HttpGet("Todo")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<PuestoPorIncidenciaDto>>> Get1A()
    {
        var puestos = await _UnitOfWork.Puestos.GetAllAsync();
        return this.mapper.Map<List<PuestoPorIncidenciaDto>>(puestos);
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
    public async Task<ActionResult<Pager<PuestoPorIncidenciaDto>>> Get1B([FromQuery] Params puestoParams)
    {
        var puestos = await _UnitOfWork.Puestos.GetAllAsync(puestoParams.PageIndex, puestoParams.PageSize, puestoParams.Search);
        var lstPuestoDto = this.mapper.Map<List<PuestoPorIncidenciaDto>>(puestos.registros);

        return new Pager<PuestoPorIncidenciaDto>(lstPuestoDto, puestos.totalRegistros, puestoParams.PageIndex, puestoParams.PageSize, puestoParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PuestoPorIncidenciaDto>> Get( string id)
    {
        var puestos = await _UnitOfWork.Puestos.GetByIdAsync(id);

        if (puestos == null) {
            return NotFound();
        }

        return this.mapper.Map<PuestoPorIncidenciaDto>(puestos);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PuestoDto>> Post(PuestoDto puestoDto)
    {
        var puesto = this.mapper.Map<Puesto>(puestoDto);
        _UnitOfWork.Puestos.Add(puesto);
        await _UnitOfWork.SaveAsync();

        if (puesto == null) {
            return BadRequest();
        }

        return this.mapper.Map<PuestoDto>(puesto);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PuestoDto>> Put(string id, [FromBody] PuestoDto puestoDto)
    {
        if (puestoDto == null) {
            return NotFound();
        }

        var puesto = this.mapper.Map<Puesto>(puestoDto);
        puesto.Id_codigo = id;
        _UnitOfWork.Puestos.Update(puesto);
        await _UnitOfWork.SaveAsync();
        
        return this.mapper.Map<PuestoDto>(puesto);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PuestoDto>> Delete(string id)
    {
        var puesto = await _UnitOfWork.Puestos.GetByIdAsync(id);
        
        if (puesto == null) {
            return NotFound();
        }

        _UnitOfWork.Puestos.Remove(puesto);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
