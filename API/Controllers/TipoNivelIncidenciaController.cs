using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
[ApiVersion("1.0")] //obtener los niveles de incidencia
[ApiVersion("1.1")] //obtener las incidencias deacuerdo a su nivel de incidencia
[ApiVersion("1.2")] //obtener paginacion, registros y buscador por nievl de incidencia 
public class TipoNivelIncidenciaController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public TipoNivelIncidenciaController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<TipoNivelIncidenciaDto>>> Get()
    {
        var tipoNiveles = await _UnitOfWork.TipoNivelIncidencias.GetAllAsync();
        return this.mapper.Map<List<TipoNivelIncidenciaDto>>(tipoNiveles);
    }

    //METODO GET (obtener todas las list)
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<TipoNivelIncidenXIncidenciaDto>>> Get1A()
    {
        var tipoNiveles = await _UnitOfWork.TipoNivelIncidencias.GetAllAsync();
        return this.mapper.Map<List<TipoNivelIncidenXIncidenciaDto>>(tipoNiveles);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<TipoNivelIncidenXIncidenciaDto>>> Get1B([FromQuery] Params nivelParams)
    {
        var tipoNiveles = await _UnitOfWork.TipoNivelIncidencias.GetAllAsync(nivelParams.PageIndex, nivelParams.PageSize, nivelParams.Search);
        var lstTipoNivelDto = this.mapper.Map<List<TipoNivelIncidenXIncidenciaDto>>(tipoNiveles.registros);

        return new Pager<TipoNivelIncidenXIncidenciaDto>(lstTipoNivelDto, tipoNiveles.totalRegistros, nivelParams.PageIndex, nivelParams.PageSize, nivelParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNivelIncidenXIncidenciaDto>> Get( int id)
    {
        var tipoNiveles = await _UnitOfWork.TipoNivelIncidencias.GetByIdAsync(id);

        if (tipoNiveles == null) {
            return NotFound();
        }

        return this.mapper.Map<TipoNivelIncidenXIncidenciaDto>(tipoNiveles);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNivelIncidenciaDto>> Post(TipoNivelIncidenciaDto tipoNivelIncidenciaDto)
    {
        var tipoNivel = this.mapper.Map<TipoNivelIncidencia>(tipoNivelIncidenciaDto);
        _UnitOfWork.TipoNivelIncidencias.Add(tipoNivel);
        await _UnitOfWork.SaveAsync();

        if (tipoNivel == null) {
            return BadRequest();
        }

        return this.mapper.Map<TipoNivelIncidenciaDto>(tipoNivel);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNivelIncidenciaDto>> Put(int id, [FromBody] TipoNivelIncidenciaDto tipoNivelIncidenciaDto)
    {
        if (tipoNivelIncidenciaDto == null) {
            return NotFound();
        }

        var tipoNivel = this.mapper.Map<TipoNivelIncidencia>(tipoNivelIncidenciaDto);
        tipoNivel.Id_codigo = id;
        _UnitOfWork.TipoNivelIncidencias.Update(tipoNivel);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<TipoNivelIncidenciaDto>(tipoNivel);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoNivelIncidenciaDto>> Delete(int id)
    {
        var tipoNivel = await _UnitOfWork.TipoNivelIncidencias.GetByIdAsync(id);
        
        if (tipoNivel == null) {
            return NotFound();
        }

        _UnitOfWork.TipoNivelIncidencias.Remove(tipoNivel);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
