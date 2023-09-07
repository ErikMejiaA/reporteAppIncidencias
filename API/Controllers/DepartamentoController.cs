using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los departamento
[ApiVersion("1.1")] //obtener las ciudades de cada departamento
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de un departamento
public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public DepartamentoController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //peticiones 
    //METODO GET (obtener todos los registros de los Dep)
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<DepartamentoDto>>> Get()
    {
        var departamentos = await _UnitOfWork.Departamentos.GetAllAsync();
        return this.mapper.Map<List<DepartamentoDto>>(departamentos);
    }

    //METODO GET (obtener todas las ciudades de los Dep)
    //[HttpGet]
    [HttpGet("Todo")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<DepartamentoCiudadDto>>> Get1A()
    {
        var depCiudad = await _UnitOfWork.Departamentos.GetAllAsync();
        return this.mapper.Map<List<DepartamentoCiudadDto>>(depCiudad);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    //[HttpGet]
    [HttpGet("Pag")]
    [Authorize]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<DepartamentoCiudadDto>>> Get1B([FromQuery] Params departParams)
    {
        var departaCiud = await _UnitOfWork.Departamentos.GetAllAsync(departParams.PageIndex, departParams.PageSize, departParams.Search);
        var lstDepCiudad = this.mapper.Map<List<DepartamentoCiudadDto>>(departaCiud.registros);

        return new Pager<DepartamentoCiudadDto>(lstDepCiudad, departaCiud.totalRegistros, departParams.PageIndex, departParams.PageSize, departParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoCiudadDto>> Get( int id)
    {
        var departamento = await _UnitOfWork.Departamentos.GetByIdAsync(id);

        if (departamento == null) {
            return NotFound();
        }

        return this.mapper.Map<DepartamentoCiudadDto>(departamento);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> Post(DepartamentoDto departamentoDto)
    {
        var departamento = this.mapper.Map<Departamento>(departamentoDto);
        _UnitOfWork.Departamentos.Add(departamento);
        await _UnitOfWork.SaveAsync();

        if (departamento == null) {
            return BadRequest();
        }

        return this.mapper.Map<DepartamentoDto>(departamento);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto departamentoDto)
    {
        if (departamentoDto == null) {
            return NotFound();
        }

        var departamento = this.mapper.Map<Departamento>(departamentoDto);
        departamento.Id_codigo = id;
        _UnitOfWork.Departamentos.Update(departamento);
        await _UnitOfWork.SaveAsync();
        return this.mapper.Map<DepartamentoDto>(departamento);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> Delete(int id)
    {
        var departamento = await _UnitOfWork.Departamentos.GetByIdAsync(id);
        
        if (departamento == null) {
            return NotFound();
        }

        _UnitOfWork.Departamentos.Remove(departamento);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
    
}
