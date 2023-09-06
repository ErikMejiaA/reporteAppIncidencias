using API.Dtos;
using API.Helpers;
using Dominio.Entities;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los salones  
[ApiVersion("1.1")] //obtener las incidencias, lospuestos que se presentan en los salones
[ApiVersion("1.2")] //obtener paginacion, registros y buscador por salon
public class SalonController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public SalonController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<SalonDto>>> Get()
    {
        var salones = await _UnitOfWork.Salones.GetAllAsync();
        return this.mapper.Map<List<SalonDto>>(salones);
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
    public async Task<ActionResult<List<SalonXInciXPuestoDto>>> Get1A()
    {
        var salones = await _UnitOfWork.Salones.GetAllAsync();
        return this.mapper.Map<List<SalonXInciXPuestoDto>>(salones);
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
    public async Task<ActionResult<Pager<SalonXInciXPuestoDto>>> Get1B([FromQuery] Params salonParams)
    {
        var salones = await _UnitOfWork.Salones.GetAllAsync(salonParams.PageIndex, salonParams.PageSize, salonParams.Search);

        var lstSalonDto = this.mapper.Map<List<SalonXInciXPuestoDto>>(salones.registros);

        return new Pager<SalonXInciXPuestoDto>(lstSalonDto, salones.totalRegistros, salonParams.PageIndex, salonParams.PageSize, salonParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalonXInciXPuestoDto>> Get( string id)
    {
        var salones = await _UnitOfWork.Salones.GetByIdAsync(id);

        if (salones == null) {
            return NotFound();
        }

        return this.mapper.Map<SalonXInciXPuestoDto>(salones);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalonDto>> Post(SalonDto salonDto)
    {
        var salon = this.mapper.Map<Salon>(salonDto);
        _UnitOfWork.Salones.Add(salon);
        await _UnitOfWork.SaveAsync();

        if (salon == null) {
            return BadRequest();
        }

        return this.mapper.Map<SalonDto>(salon);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalonDto>> Put(string id, [FromBody] SalonDto salonDto)
    {
        if (salonDto == null) {
            return NotFound();
        }

        var salon = this.mapper.Map<Salon>(salonDto);
        salon.Id_codigo = id;
        _UnitOfWork.Salones.Update(salon);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<SalonDto>(salon);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalonDto>> Delete(string id)
    {
        var salon = await _UnitOfWork.Salones.GetByIdAsync(id);
        
        if (salon == null) {
            return NotFound();
        }

        _UnitOfWork.Salones.Remove(salon);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
