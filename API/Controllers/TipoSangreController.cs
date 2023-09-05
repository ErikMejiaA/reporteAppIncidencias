using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los tipos de sangre
[ApiVersion("1.1")] //obtener las personas con su tipo de sangre
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de tipos de sangre
public class TipoSangreController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public TipoSangreController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<TipoSangreDto>>> Get()
    {
        var tiposSangre = await _UnitOfWork.TiposSangre.GetAllAsync();
        return this.mapper.Map<List<TipoSangreDto>>(tiposSangre);
    }

    //METODO GET (obtener todas las list)
    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TipoSangreXpersonaDto>>> Get1A()
    {
        var tiposSangre = await _UnitOfWork.TiposSangre.GetAllAsync();
        return this.mapper.Map<List<TipoSangreXpersonaDto>>(tiposSangre);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<TipoSangreXpersonaDto>>> Get1B([FromQuery] Params sangreParams)
    {
        var tiposSangre = await _UnitOfWork.TiposSangre.GetAllAsync(sangreParams.PageIndex, sangreParams.PageSize, sangreParams.Search);
        var lstSangreDto = this.mapper.Map<List<TipoSangreXpersonaDto>>(tiposSangre.registros);

        return new Pager<TipoSangreXpersonaDto>(lstSangreDto, tiposSangre.totalRegistros, sangreParams.PageIndex, sangreParams.PageSize, sangreParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoSangreXpersonaDto>> Get( int id)
    {
        var tipoSangre = await _UnitOfWork.TiposSangre.GetByIdAsync(id);

        if (tipoSangre == null) {
            return NotFound();
        }

        return this.mapper.Map<TipoSangreXpersonaDto>(tipoSangre);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoSangreDto>> Post(TipoSangreDto tipoSangreDto)
    {
        var tipoSangre = this.mapper.Map<TipoSangre>(tipoSangreDto);
        _UnitOfWork.TiposSangre.Add(tipoSangre);
        await _UnitOfWork.SaveAsync();

        if (tipoSangre == null) {
            return BadRequest();
        }

        return this.mapper.Map<TipoSangreDto>(tipoSangre);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoSangreDto>> Put(int id, [FromBody] TipoSangreDto tipoSangreDto)
    {
        if (tipoSangreDto == null) {
            return NotFound();
        }

        var tipoSangre = this.mapper.Map<TipoSangre>(tipoSangreDto);
        tipoSangre.Id_codigo = id;
        _UnitOfWork.TiposSangre.Update(tipoSangre);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<TipoSangreDto>(tipoSangre);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoSangreDto>> Delete(int id)
    {
        var tipoSangre = await _UnitOfWork.TiposSangre.GetByIdAsync(id);
        
        if (tipoSangre == null) {
            return NotFound();
        }

        _UnitOfWork.TiposSangre.Remove(tipoSangre);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
