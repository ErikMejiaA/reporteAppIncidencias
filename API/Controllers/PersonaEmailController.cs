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
public class PersonaEmailController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public PersonaEmailController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<PersonaEmailDto>>> Get()
    {
        var emails = await _UnitOfWork.PersonaEmails.GetAllAsync();
        return this.mapper.Map<List<PersonaEmailDto>>(emails);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<PersonaEmailDto>>> Get1B([FromQuery] Params emailParams)
    {
        var emails = await _UnitOfWork.PersonaEmails.GetAllAsync(emailParams.PageIndex, emailParams.PageSize, emailParams.Search);

        var lstEmailDto = this.mapper.Map<List<PersonaEmailDto>>(emails.registros);

        return new Pager<PersonaEmailDto>(lstEmailDto, emails.totalRegistros, emailParams.PageIndex, emailParams.PageSize, emailParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{idPerson}/{idTipoEmail}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaEmailDto>> Get( string idPerson, int idTipoEmail)
    {
        var email = await _UnitOfWork.PersonaEmails.GetByIdAsync(idPerson, idTipoEmail);

        if (email == null) {
            return NotFound();
        }

        return this.mapper.Map<PersonaEmailDto>(email);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaEmailDto>> Post(PersonaEmailDto personaEmailDto)
    {
        var email = this.mapper.Map<PersonaEmail>(personaEmailDto);
        _UnitOfWork.PersonaEmails.Add(email);
        await _UnitOfWork.SaveAsync();

        if (email == null) {
            return BadRequest();
        }

        return this.mapper.Map<PersonaEmailDto>(email);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{idPerson}/{idTipoEmail}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaEmailDto>> Put(string idPerson, int idTipoEmail, [FromBody] PersonaEmailDto personaEmailDto)
    {
        if (personaEmailDto == null) {
            return NotFound();
        }

        var email = this.mapper.Map<PersonaEmail>(personaEmailDto);
        email.Id_personaFK = idPerson;
        email.Id_tipoEmailFK = idTipoEmail;
        _UnitOfWork.PersonaEmails.Update(email);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<PersonaEmailDto>(email);        
    }

     //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{idPerson}/{idTipoEmail}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaEmailDto>> Delete(string idPerson, int idTipoEmail)
    {
        var email = await _UnitOfWork.PersonaEmails.GetByIdAsync (idPerson, idTipoEmail);
        
        if (email == null) {
            return NotFound();
        }

        _UnitOfWork.PersonaEmails.Remove(email);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
