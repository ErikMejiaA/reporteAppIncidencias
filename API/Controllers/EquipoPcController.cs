using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtner los Equipos
[ApiVersion("1.1")] //obtener las listas de puestos que contiene equipo
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de Equipos
public class EquipoPcController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public EquipoPcController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<EquipoPcDto>>> Get()
    {
        var equiposPc = await _UnitOfWork.EquipoPcs.GetAllAsync();
        return this.mapper.Map<List<EquipoPcDto>>(equiposPc);
    }

    //METODO GET (obtener todas las list que pertenecen a un equipo)
    //[HttpGet]
    [HttpGet("Todo")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<EquipoPcRecusosDto>>> Get1A()
    {
        var equiposPc = await _UnitOfWork.EquipoPcs.GetAllAsync();
        return this.mapper.Map<List<EquipoPcRecusosDto>>(equiposPc);
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
    public async Task<ActionResult<Pager<EquipoPcRecusosDto>>> Get1B([FromQuery] Params equiParams)
    {
        var equiposPc = await _UnitOfWork.EquipoPcs.GetAllAsync(equiParams.PageIndex, equiParams.PageSize, equiParams.Search);
        var lstEquipoPcDto = this.mapper.Map<List<EquipoPcRecusosDto>>(equiposPc.registros);

        return new Pager<EquipoPcRecusosDto>(lstEquipoPcDto, equiposPc.totalRegistros, equiParams.PageIndex, equiParams.PageSize, equiParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EquipoPcRecusosDto>> Get( string id)
    {
        var equipoPc = await _UnitOfWork.EquipoPcs.GetByIdAsync(id);

        if (equipoPc == null) {
            return NotFound();
        }

        return this.mapper.Map<EquipoPcRecusosDto>(equipoPc);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EquipoPcDto>> Post(EquipoPcDto equipoPcDto)
    {
        var equipoPc = this.mapper.Map<EquipoPc>(equipoPcDto);
        _UnitOfWork.EquipoPcs.Add(equipoPc);
        await _UnitOfWork.SaveAsync();

        if (equipoPc == null) {
            return BadRequest();
        }

        return this.mapper.Map<EquipoPcDto>(equipoPc);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EquipoPcDto>> Put(string id, [FromBody] EquipoPcDto equipoPcDto)
    {
        if (equipoPcDto == null) {
            return NotFound();
        }

        var equipoPc = this.mapper.Map<EquipoPc>(equipoPcDto);
        equipoPc.Id_codigo = id;
        _UnitOfWork.EquipoPcs.Update(equipoPc);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<EquipoPcDto>(equipoPc);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EquipoPcDto>> Delete(string id)
    {
        var equipoPc = await _UnitOfWork.EquipoPcs.GetByIdAsync(id);
        
        if (equipoPc == null) {
            return NotFound();
        }

        _UnitOfWork.EquipoPcs.Remove(equipoPc);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}