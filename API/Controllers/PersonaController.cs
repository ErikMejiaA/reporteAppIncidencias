using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener las personas
[ApiVersion("1.1")] //obtener loda la inf de las personas
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de una persona
public class PersonaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public PersonaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones 
    //METODO GET (obtener todos los registros de las personas)
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<PersonaDto>>> Get()
    {
        var personas = await _UnitOfWork.Personas.GetAllAsync();
        return this.mapper.Map<List<PersonaDto>>(personas);
    }

    //METODO GET (obtener todas la inf de las persona)
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<PersonaListTodoDto>>> Get1A()
    {
        var personas = await _UnitOfWork.Personas.GetAllAsync();
        return this.mapper.Map<List<PersonaListTodoDto>>(personas);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<PersonaListTodoDto>>> Get1B([FromQuery] Params personaParams)
    {
        var personas = await _UnitOfWork.Personas.GetAllAsync(personaParams.PageIndex, personaParams.PageSize, personaParams.Search);
        
        var lstPersonaDto = this.mapper.Map<List<PersonaListTodoDto>>(personas.registros);

        return new Pager<PersonaListTodoDto>(lstPersonaDto, personas.totalRegistros, personaParams.PageIndex, personaParams.PageSize, personaParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaListTodoDto>> Get( string id)
    {
        var personas = await _UnitOfWork.Personas.GetByIdAsync(id);

        if (personas == null) {
            return NotFound();
        }

        return this.mapper.Map<PersonaListTodoDto>(personas);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaDto>> Post(PersonaDto personaDto)
    {
        var persona = this.mapper.Map<Persona>(personaDto);
        _UnitOfWork.Personas.Add(persona);
        await _UnitOfWork.SaveAsync();

        if (persona == null) {
            return BadRequest();
        }

        return this.mapper.Map<PersonaDto>(persona);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaDto>> Put(string id, [FromBody] PersonaDto personaDto)
    {
        if (personaDto == null) {
            return NotFound();
        }

        var persona = this.mapper.Map<Persona>(personaDto);
        persona.Id_codigo = id;
        _UnitOfWork.Personas.Update(persona);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<PersonaDto>(persona);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaDto>> Delete(string id)
    {
        var persona = await _UnitOfWork.Personas.GetByIdAsync(id);
        
        if (persona == null) {
            return NotFound();
        }

        _UnitOfWork.Personas.Remove(persona);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
