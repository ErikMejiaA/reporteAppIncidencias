using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los tipos de telefonos moviles
[ApiVersion("1.1")] //obtener las personas con su tipo de telefonos
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de tipos de telefono
public class TipoTelefonoMovilController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public TipoTelefonoMovilController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<TipoTelefonoMovilDto>>> Get()
    {
        var tipoMoviles = await _UnitOfWork.TipoTelefonoMoviles.GetAllAsync();
        return this.mapper.Map<List<TipoTelefonoMovilDto>>(tipoMoviles);
    }

    //METODO GET (obtener todas las list)
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TipoTeleMoviXpersonaTeleMoviDto>>> Get1A()
    {
        var tipoMoviles = await _UnitOfWork.TipoTelefonoMoviles.GetAllAsync();
        return this.mapper.Map<List<TipoTeleMoviXpersonaTeleMoviDto>>(tipoMoviles);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<TipoTeleMoviXpersonaTeleMoviDto>>> Get1B([FromQuery] Params movilParams)
    {
        var tipoMoviles = await _UnitOfWork.TipoTelefonoMoviles.GetAllAsync(movilParams.PageIndex, movilParams.PageSize, movilParams.Search);

        var lstMovilesDto = this.mapper.Map<List<TipoTeleMoviXpersonaTeleMoviDto>>(tipoMoviles.registros);

        return new Pager<TipoTeleMoviXpersonaTeleMoviDto>(lstMovilesDto, tipoMoviles.totalRegistros, movilParams.PageIndex, movilParams.PageSize, movilParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoTeleMoviXpersonaTeleMoviDto>> Get( int id)
    {
        var tipoMovil = await _UnitOfWork.TipoTelefonoMoviles.GetByIdAsync(id);

        if (tipoMovil == null) {
            return NotFound();
        }

        return this.mapper.Map<TipoTeleMoviXpersonaTeleMoviDto>(tipoMovil);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoTelefonoMovilDto>> Post(TipoTelefonoMovilDto tipoTelefonoMovilDto)
    {
        var tipoMovil = this.mapper.Map<TipoTelefonoMovil>(tipoTelefonoMovilDto);
        _UnitOfWork.TipoTelefonoMoviles.Add(tipoMovil);
        await _UnitOfWork.SaveAsync();

        if (tipoMovil == null) {
            return BadRequest();
        }

        return this.mapper.Map<TipoTelefonoMovilDto>(tipoMovil);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoTelefonoMovilDto>> Put(int id, [FromBody] TipoTelefonoMovilDto tipoTelefonoMovilDto)
    {
        if (tipoTelefonoMovilDto == null) {
            return NotFound();
        }

        var tipoMovil = this.mapper.Map<TipoTelefonoMovil>(tipoTelefonoMovilDto);
        tipoMovil.Id_codigo = id;
        _UnitOfWork.TipoTelefonoMoviles.Update(tipoMovil);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<TipoTelefonoMovilDto>(tipoMovil);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoTelefonoMovilDto>> Delete(int id)
    {
        var tipoMovil = await _UnitOfWork.TipoTelefonoMoviles.GetByIdAsync(id);
        
        if (tipoMovil == null) {
            return NotFound();
        }

        _UnitOfWork.TipoTelefonoMoviles.Remove(tipoMovil);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
    
}
