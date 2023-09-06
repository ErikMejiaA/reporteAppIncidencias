using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener la relacion entre Usuario y rol
[ApiVersion("1.1")] // por definir
[ApiVersion("1.2")] //obtener paginacion, registros y buscador de usuariosRoles
public class UsuariosRolesController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly Mapper mapper;

    public UsuariosRolesController(IUnitOfWorkInterface UnitOfWork, Mapper mapper)
    {
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO GET (obtener todos los registros)
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UsuariosRolesDto>>> Get()
    {
        var usuariosRoles = await _UnitOfWork.UsuariosRoles.GetAllAsync();
        return this.mapper.Map<List<UsuariosRolesDto>>(usuariosRoles);
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
    public async Task<ActionResult<Pager<UsuariosRolesDto>>> Get1B([FromQuery] Params usuarioParams)
    {
        var usuariosRoles = await _UnitOfWork.UsuariosRoles.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);

        var lstUsuRolDto = this.mapper.Map<List<UsuariosRolesDto>>(usuariosRoles.registros);

        return new Pager<UsuariosRolesDto>(lstUsuRolDto, usuariosRoles.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }

    //METODO GET POR ID (Traer un solo registro de la entidad de la  Db)
    [HttpGet("{idUsua}/{idRol}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuariosRolesDto>> Get( int idUsua, int idRol)
    {
        var usuarioRol = await _UnitOfWork.UsuariosRoles.GetByIdAsync(idUsua, idRol);

        if (usuarioRol == null) {
            return NotFound();
        }

        return this.mapper.Map<UsuariosRolesDto>(usuarioRol);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuariosRolesDto>> Post(UsuariosRolesDto usuariosRolesDto)
    {
        var usuarioRol = this.mapper.Map<UsuariosRoles>(usuariosRolesDto);
        _UnitOfWork.UsuariosRoles.Add(usuarioRol);
        await _UnitOfWork.SaveAsync();

        if (usuarioRol == null) {
            return BadRequest();
        }

        return this.mapper.Map<UsuariosRolesDto>(usuarioRol);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{idUsua}/{idRol}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuariosRolesDto>> Put(int idUsua, int idRol, [FromBody] UsuariosRolesDto usuariosRolesDto)
    {
        if (usuariosRolesDto == null) {
            return NotFound();
        }

        var usuarioRol = this.mapper.Map<UsuariosRoles>(usuariosRolesDto);
        usuarioRol.UsuarioId = idUsua;
        usuarioRol.RolId = idRol;
        _UnitOfWork.UsuariosRoles.Update(usuarioRol);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<UsuariosRolesDto>(usuarioRol);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{idUsua}/{idRol}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuariosRolesDto>> Delete(int idUsua, int idRol)
    {
        var usuarioRol = await _UnitOfWork.UsuariosRoles.GetByIdAsync (idUsua, idRol);
        
        if (usuarioRol == null) {
            return NotFound();
        }

        _UnitOfWork.UsuariosRoles.Remove(usuarioRol);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
