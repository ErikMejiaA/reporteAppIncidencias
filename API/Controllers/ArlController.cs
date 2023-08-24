using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtner las Arl 
[ApiVersion("1.1")] //obtener Arl con sus usuarios
[ApiVersion("1.2")] //obtener paginacion, registros y buscador en Arl
public class ArlController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public ArlController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<ArlDto>>> Get()
    {
        var arls = await _UnitOfWork.Arl.GetAllAsync();
        return this.mapper.Map<List<ArlDto>>(arls);
    }

    //METODO GET (obtener todas las Arl con sus Usuarios)
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ArlPorPersonaDto>>> Get1A()
    {
        var arlPersonas = await _UnitOfWork.Arl.GetAllAsync();
        return this.mapper.Map<List<ArlPorPersonaDto>>(arlPersonas);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<ArlPorPersonaDto>>> Get1B([FromQuery] Params arlParams)
    {
        var arlPersonas = await _UnitOfWork.Arl.GetAllAsync(arlParams.PageIndex, arlParams.PageSize, arlParams.Search);
        var lstArlPersonas = this.mapper.Map<List<ArlPorPersonaDto>>(arlPersonas.registros);

        return new Pager<ArlPorPersonaDto>(lstArlPersonas, arlPersonas.totalRegistros, arlParams.PageIndex, arlParams.PageSize, arlParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ArlPorPersonaDto>> Get( int id)
    {
        var arlPersona = await _UnitOfWork.Arl.GetByIdAsync(id);

        if (arlPersona == null) {
            return NotFound();
        }

        return this.mapper.Map<ArlPorPersonaDto>(arlPersona);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ArlDto>> Post(ArlDto arlDto)
    {
        var arl = this.mapper.Map<Arl>(arlDto);
        _UnitOfWork.Arl.Add(arl);
        await _UnitOfWork.SaveAsync();

        if (arl == null) {
            return BadRequest();
        }

        return this.mapper.Map<ArlDto>(arl);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ArlDto>> Put(int id, [FromBody] ArlDto arlDto)
    {
        if (arlDto == null) {
            return NotFound();
        }

        var arl = this.mapper.Map<Arl>(arlDto);
        arl.Id_codigo = id;
        _UnitOfWork.Arl.Update(arl);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<ArlDto>(arl);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ArlDto>> Delete(int id)
    {
        var arl = await _UnitOfWork.Arl.GetByIdAsync(id);
        
        if (arl == null) {
            return NotFound();
        }

        _UnitOfWork.Arl.Remove(arl);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }


}
