using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los personas con sus telefononos
[ApiVersion("1.1")] //obtener las listas
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de la persona con su telefono
public class PersonaTelefonoMovilController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public PersonaTelefonoMovilController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<PersonaTelefonoMovilDto>>> Get()
    {
        var moviles = await _UnitOfWork.PersonaTelefonoMoviles.GetAllAsync();
        return this.mapper.Map<List<PersonaTelefonoMovilDto>>(moviles);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<PersonaTelefonoMovilDto>>> Get1B([FromQuery] Params movilParams)
    {
        var moviles = await _UnitOfWork.PersonaTelefonoMoviles.GetAllAsync(movilParams.PageIndex, movilParams.PageSize, movilParams.Search);

        var lstMovilesDto = this.mapper.Map<List<PersonaTelefonoMovilDto>>(moviles.registros);

        return new Pager<PersonaTelefonoMovilDto>(lstMovilesDto, moviles.totalRegistros, movilParams.PageIndex, movilParams.PageSize, movilParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{idPerson}/{idTipoTelMov}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaTelefonoMovilDto>> Get( string idPerson, int idTipoTelMov)
    {
        var movil = await _UnitOfWork.PersonaTelefonoMoviles.GetByIdAsync(idPerson, idTipoTelMov);

        if (movil == null) {
            return NotFound();
        }

        return this.mapper.Map<PersonaTelefonoMovilDto>(movil);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaTelefonoMovilDto>> Post(PersonaTelefonoMovilDto personaTelefonoMovilDto)
    {
        var movil = this.mapper.Map<PersonaTelefonoMovil>(personaTelefonoMovilDto);
        _UnitOfWork.PersonaTelefonoMoviles.Add(movil);
        await _UnitOfWork.SaveAsync();

        if (movil == null) {
            return BadRequest();
        }

        return this.mapper.Map<PersonaTelefonoMovilDto>(movil);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{idPerson}/{idTipoTelMov}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaTelefonoMovilDto>> Put(string idPerson, int idTipoTelMov, [FromBody] PersonaTelefonoMovilDto personaTelefonoMovilDto)
    {
        if (personaTelefonoMovilDto == null) {
            return NotFound();
        }

        var movil = this.mapper.Map<PersonaTelefonoMovil>(personaTelefonoMovilDto);
        movil.Id_personaFK = idPerson;
        movil.Id_tipoTelefonoMovilFK = idTipoTelMov;
        _UnitOfWork.PersonaTelefonoMoviles.Update(movil);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<PersonaTelefonoMovilDto>(movil);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{idPerson}/{idTipoTelMov}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaTelefonoMovilDto>> Delete(string idPerson, int idTipoTelMov)
    {
        var movilTel = await _UnitOfWork.PersonaTelefonoMoviles.GetByIdAsync (idPerson, idTipoTelMov);
        
        if (movilTel == null) {
            return NotFound();
        }

        _UnitOfWork.PersonaTelefonoMoviles.Remove(movilTel);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
