using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtner las categorias
[ApiVersion("1.1")] //obtener categorias con incidencias y Recursos
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de categoria
public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public CategoriaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }
    //peticiones 

    //METODO GET (obtener todos los registros de categoria)
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<CategoriaDto>>> Get()
    {
        var categorias = await _UnitOfWork.Categorias.GetAllAsync();
        return this.mapper.Map<List<CategoriaDto>>(categorias);
    }

    //METODO GET (obtener todas las categorias con sus incidencias y componentes)
    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<CategoriaIncideRecurDto>>> Get1A()
    {
        var categIncidRecur = await _UnitOfWork.Categorias.GetAllAsync();
        return this.mapper.Map<List<CategoriaIncideRecurDto>>(categIncidRecur);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<CategoriaIncideRecurDto>>> Get1B([FromQuery] Params categoriaParams)
    {
        var categoriasInRe = await _UnitOfWork.Categorias.GetAllAsync(categoriaParams.PageIndex, categoriaParams.PageSize, categoriaParams.Search);
        var lstCategoriasInRe = this.mapper.Map<List<CategoriaIncideRecurDto>>(categoriasInRe.registros);

        return new Pager<CategoriaIncideRecurDto>(lstCategoriasInRe, categoriasInRe.totalRegistros, categoriaParams.PageIndex, categoriaParams.PageSize, categoriaParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaIncideRecurDto>> Get( int id)
    {
        var categoriaInRe = await _UnitOfWork.Categorias.GetByIdAsync(id);

        if (categoriaInRe == null) {
            return NotFound();
        }

        return this.mapper.Map<CategoriaIncideRecurDto>(categoriaInRe);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> Post(CategoriaDto categoriaDto)
    {
        var categoriaInRe = this.mapper.Map<Categoria>(categoriaDto);
        _UnitOfWork.Categorias.Add(categoriaInRe);
        await _UnitOfWork.SaveAsync();

        if (categoriaInRe == null) {
            return BadRequest();
        }

        return this.mapper.Map<CategoriaDto>(categoriaInRe);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> Put(int id, [FromBody] CategoriaDto categoriaDto)
    {
        if (categoriaDto == null) {
            return NotFound();
        }

        var categoria = this.mapper.Map<Categoria>(categoriaDto);
        categoria.Id_codigo = id;
        _UnitOfWork.Categorias.Update(categoria);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<CategoriaDto>(categoria);        
    }

     //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> Delete(int id)
    {
        var categoria = await _UnitOfWork.Categorias.GetByIdAsync(id);
        
        if (categoria == null) {
            return NotFound();
        }

        _UnitOfWork.Categorias.Remove(categoria);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
