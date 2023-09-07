using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los usuarios registrados
[ApiVersion("1.1")] //obtener los usuarios y los roles 
[ApiVersion("1.2")] //obtener paginacion, registros y buscador nulo
public class UsuarioController : BaseApiController
{
    private readonly IUserServiceInterface _userService;
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public UsuarioController(IUserServiceInterface userService, IUnitOfWorkInterface UnitOfWork, IMapper mapper)
    {
        _userService = userService;
        _UnitOfWork = UnitOfWork;
        this.mapper = mapper;
    }

    //METODO POST (REGISTRA USUARIO)
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RegisterAsync(RegisterDto model)
    {
        var result = await _userService.RegisterAsync(model);
        return Ok(result);
    }

    //METODO POST (OBTENER TOKEN DEL USUSARIO REGISTRADO)
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTokenAsync(LoginDto model)
    {
        var result = await _userService.GetTokenAsync(model);
        return Ok(result);
    }

    //METODO POST (PARA AÑADIR ROL A USUARIO REGSITRADO)
    [HttpPost("addrole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddRoleAsync(AddRoleDto model)
    {
        var result = await _userService.AddRoleAsync(model);
        return Ok(result);
    }

    //METODO GET (OBTENER LOS USUARIOS REGISTRADOS)
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UsuarioDto>>> Get()
    {
        var usuarios = await _UnitOfWork.Usuarios.GetAllAsync();
        return this.mapper.Map<List<UsuarioDto>>(usuarios);
    }

    //METODO GET (OBTENER LOS USUARIOS CON SU ROL)
    [HttpGet("verUsuariosXroles")]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UsuarioXrolDto>>> Get1A()
    {
        var usuariosRoles = await _UnitOfWork.Usuarios.GetAllAsync();
        return this.mapper.Map<List<UsuarioXrolDto>>(usuariosRoles);
    }

    //METODO GET POR ID (TRAER UN UNICO REGISTRO CON SUS ROLES)
    [HttpGet("{id}")]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioXrolDto>> Get(int id)
    {
        var usuarioXrol = await _UnitOfWork.Usuarios.GetByIdAsync(id);

        if (usuarioXrol == null) {
            return NotFound();
        }

        return this.mapper.Map<UsuarioXrolDto>(usuarioXrol);
    }

    //METODO GET (Para obtener paginacion, registro y busqueda en la entidad)
    //[HttpGet]
    [HttpGet("Pag")]
    [Authorize(Roles = "Administrador")]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pager<UsuarioXrolDto>>> Get1B([FromQuery] Params usuarioParams)
    {
        var usuariosXroles = await _UnitOfWork.Usuarios.GetAllAsync(usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
        var lstUsuarioXrolDto = this.mapper.Map<List<UsuarioXrolDto>>(usuariosXroles.registros);

        return new Pager<UsuarioXrolDto>(lstUsuarioXrolDto, usuariosXroles.totalRegistros, usuarioParams.PageIndex, usuarioParams.PageSize, usuarioParams.Search);
    }


    //METODO PUT (EDITAR UN USUARIO)
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody]UsuarioDto usuarioDto)
    {
        if (usuarioDto == null) {
            return NotFound();
        }

        var usuario = this.mapper.Map<Usuario>(usuarioDto);
        usuario.Id_codigo = id;
        var editUsuario = await _userService.EditarUsuarioAsync(usuario);
        return this.mapper.Map<UsuarioDto>(editUsuario);
    }

    //METODO DELETE (BORRAR USUARIO REGISTRADO)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> Delete(int id)
    {
        var usuario = await _UnitOfWork.Usuarios.GetByIdAsync(id);

        if(usuario == null) {
            return NotFound();
        }

        _UnitOfWork.Usuarios.Remove(usuario);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }

}
