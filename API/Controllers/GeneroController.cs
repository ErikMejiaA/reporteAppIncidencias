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
public class GeneroController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public GeneroController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<GeneroDto>>> Get()
    {
        var generos = await _UnitOfWork.Generos.GetAllAsync();
        return this.mapper.Map<List<GeneroDto>>(generos);
    }

    //METODO GET (obtener todas las list)
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<GeneroPersonaDto>>> Get1A()
    {
        var generosP = await _UnitOfWork.Generos.GetAllAsync();
        return this.mapper.Map<List<GeneroPersonaDto>>(generosP);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<GeneroPersonaDto>>> Get1B([FromQuery] Params generoParams)
    {
        var generoP = await _UnitOfWork.Generos.GetAllAsync(generoParams.PageIndex, generoParams.PageSize, generoParams.Search);
        var lstGeneroPDto = this.mapper.Map<List<GeneroPersonaDto>>(generoP.registros);

        return new Pager<GeneroPersonaDto>(lstGeneroPDto, generoP.totalRegistros, generoParams.PageIndex, generoParams.PageSize, generoParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GeneroPersonaDto>> Get( int id)
    {
        var genero = await _UnitOfWork.Generos.GetByIdAsync(id);

        if (genero == null) {
            return NotFound();
        }

        return this.mapper.Map<GeneroPersonaDto>(genero);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GeneroDto>> Post(GeneroDto generoDto)
    {
        var genero = this.mapper.Map<Genero>(generoDto);
        _UnitOfWork.Generos.Add(genero);
        await _UnitOfWork.SaveAsync();

        if (genero == null) {
            return BadRequest();
        }

        return this.mapper.Map<GeneroDto>(genero);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GeneroDto>> Put(int id, [FromBody] GeneroDto generoDto)
    {
        if (generoDto == null) {
            return NotFound();
        }

        var genero = this.mapper.Map<Genero>(generoDto);
        genero.Id_codigo = id;
        _UnitOfWork.Generos.Update(genero);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<GeneroDto>(genero);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GeneroDto>> Delete(int id)
    {
        var genero = await _UnitOfWork.Generos.GetByIdAsync(id);
        
        if (genero == null) {
            return NotFound();
        }

        _UnitOfWork.Generos.Remove(genero);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
