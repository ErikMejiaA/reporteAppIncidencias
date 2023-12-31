using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtner los tipos de cargos de la persona
[ApiVersion("1.1")] //obtener las personas por el tipo de cargo 
[ApiVersion("1.2")] //obtener paginacion, registros y buscador por tipo de persona o cargo
public class RolController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public RolController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<RolDto>>> Get()
    {
        var roles = await _UnitOfWork.Roles.GetAllAsync();
        return this.mapper.Map<List<RolDto>>(roles);
    }

    //METODO GET (obtener todas las list de usuarios y roles)
    //[HttpGet]
    [HttpGet("Todo")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<RolXusuarioXUusuariosRolesDto>>> Get1A()
    {
        var roles = await _UnitOfWork.Roles.GetAllAsync();
        return this.mapper.Map<List<RolXusuarioXUusuariosRolesDto>>(roles);
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
    public async Task<ActionResult<Pager<RolXusuarioXUusuariosRolesDto>>> Get1B([FromQuery] Params rolParams)
    {
        var roles = await _UnitOfWork.Roles.GetAllAsync(rolParams.PageIndex, rolParams.PageSize, rolParams.Search);

        var lstTipoPersonaDto = this.mapper.Map<List<RolXusuarioXUusuariosRolesDto>>(roles.registros);

        return new Pager<RolXusuarioXUusuariosRolesDto>(lstTipoPersonaDto, roles.totalRegistros, rolParams.PageIndex, rolParams.PageSize, rolParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolXusuarioXUusuariosRolesDto>> Get( int id)
    {
        var rol = await _UnitOfWork.Roles.GetByIdAsync(id);

        if (rol == null) {
            return NotFound();
        }

        return this.mapper.Map<RolXusuarioXUusuariosRolesDto>(rol);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Post(RolDto rolDto)
    {
        var rol = this.mapper.Map<Rol>(rolDto);
        _UnitOfWork.Roles.Add(rol);
        await _UnitOfWork.SaveAsync();

        if (rol == null) {
            return BadRequest();
        }

        return this.mapper.Map<RolDto>(rol);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto rolDto)
    {
        if (rolDto == null) {
            return NotFound();
        }

        var rol = this.mapper.Map<Rol>(rolDto);
        rol.Id_codigo = id;
        _UnitOfWork.Roles.Update(rol);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<RolDto>(rol);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Delete(int id)
    {
        var rol = await _UnitOfWork.Roles.GetByIdAsync(id);
        
        if (rol == null) {
            return NotFound();
        }

        _UnitOfWork.Roles.Remove(rol);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }
}
