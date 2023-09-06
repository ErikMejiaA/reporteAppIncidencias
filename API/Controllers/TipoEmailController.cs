using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los tipos de Email
[ApiVersion("1.1")] //obtener las personas con sus tipo Email
[ApiVersion("1.2")] //obtener paginacion, registros y buscador por persona su tipo email
public class TipoEmailController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public TipoEmailController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<TipoEmailDto>>> Get()
    {
        var tipoEmails = await _UnitOfWork.TipoEmails.GetAllAsync();
        return this.mapper.Map<List<TipoEmailDto>>(tipoEmails);
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
    public async Task<ActionResult<List<TipoEmailXPersonaDto>>> Get1A()
    {
        var tipoEmails = await _UnitOfWork.TipoEmails.GetAllAsync();
        return this.mapper.Map<List<TipoEmailXPersonaDto>>(tipoEmails);
    }

    //[HttpGet]
    [HttpGet("Pag")]
    [Authorize]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<TipoEmailXPersonaDto>>> Get1B([FromQuery] Params emailParams)
    {
        var tipoEmails = await _UnitOfWork.TipoEmails.GetAllAsync(emailParams.PageIndex, emailParams.PageSize, emailParams.Search);
        var lstEmailDTo = this.mapper.Map<List<TipoEmailXPersonaDto>>(tipoEmails.registros);

        return new Pager<TipoEmailXPersonaDto>(lstEmailDTo, tipoEmails.totalRegistros, emailParams.PageIndex, emailParams.PageSize, emailParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoEmailXPersonaDto>> Get( int id)
    {
        var tipoEmails = await _UnitOfWork.TipoEmails.GetByIdAsync(id);

        if (tipoEmails == null) {
            return NotFound();
        }

        return this.mapper.Map<TipoEmailXPersonaDto>(tipoEmails);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoEmailDto>> Post(TipoEmailDto tipoEmailDto)
    {
        var tipoEmail = this.mapper.Map<TipoEmail>(tipoEmailDto);
        _UnitOfWork.TipoEmails.Add(tipoEmail);
        await _UnitOfWork.SaveAsync();

        if (tipoEmail == null) {
            return BadRequest();
        }

        return this.mapper.Map<TipoEmailDto>(tipoEmail);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoEmailDto>> Put(int id, [FromBody] TipoEmailDto tipoEmailDto)
    {
        if (tipoEmailDto == null) {
            return NotFound();
        }

        var tipoEmail = this.mapper.Map<TipoEmail>(tipoEmailDto);
        tipoEmail.Id_codigo = id;
        _UnitOfWork.TipoEmails.Update(tipoEmail);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<TipoEmailDto>(tipoEmail);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoEmailDto>> Delete(int id)
    {
        var tipoEmail = await _UnitOfWork.TipoEmails.GetByIdAsync(id);
        
        if (tipoEmail == null) {
            return NotFound();
        }

        _UnitOfWork.TipoEmails.Remove(tipoEmail);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
