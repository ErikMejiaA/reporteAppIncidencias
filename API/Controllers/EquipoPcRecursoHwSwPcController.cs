using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")] //obtener los Equipos de Computo
[ApiVersion("1.1")] //obtener las listas de los componentes del Pc
[ApiVersion("1.2")] //obtener paginacion, registros y buscador
public class EquipoPcRecursoHwSwPcController : BaseApiController
{
    private readonly IUnitOfWorkInterface _UnitOfWork;
    private readonly IMapper mapper;

    public EquipoPcRecursoHwSwPcController(IUnitOfWorkInterface UnitOfWork, IMapper mapper)
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
    public async Task<ActionResult<List<EquipoPcRecursoHwSwPcDto>>> Get()
    {
        var equipoPcs = await _UnitOfWork.EquipoPcRecursoHwSwPcs.GetAllAsync();
        return this.mapper.Map<List<EquipoPcRecursoHwSwPcDto>>(equipoPcs);
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
    public async Task<ActionResult<Pager<EquipoPcRecursoHwSwPcDto>>> Get1B([FromQuery] Params equipoParms)
    {
        var equiposPcs = await _UnitOfWork.EquipoPcRecursoHwSwPcs.GetAllAsync(equipoParms.PageIndex, equipoParms.PageSize, equipoParms.Search);

        var lstEquipoDto = this.mapper.Map<List<EquipoPcRecursoHwSwPcDto>>(equiposPcs.registros);

        return new Pager<EquipoPcRecursoHwSwPcDto>(lstEquipoDto, equiposPcs.totalRegistros, equipoParms.PageIndex, equipoParms.PageSize, equipoParms.Search);
    }

    //METODO POST (para enviar registros a la entidad de la Db)
    [HttpPost]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EquipoPcRecursoHwSwPcDto>> Post(EquipoPcRecursoHwSwPcDto equipoPcRecursoHwSwPcDto)
    {
        var equipoPc = this.mapper.Map<EquipoPcRecursoHwSwPc>(equipoPcRecursoHwSwPcDto);
        _UnitOfWork.EquipoPcRecursoHwSwPcs.Add(equipoPc);
        await _UnitOfWork.SaveAsync();

        if (equipoPc == null) {
            return BadRequest();
        }

        return this.mapper.Map<EquipoPcRecursoHwSwPcDto>(equipoPc);
    }

    //METODO PUT (editar un registro de la entidad de la Db)
    [HttpPut("{idEquiPc}/{idRecurso}")]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EquipoPcRecursoHwSwPcDto>> Put(string idEquiPc, int idRecurso, [FromBody] EquipoPcRecursoHwSwPcDto equipoPcRecursoHwSwPcDto)
    {
        if (equipoPcRecursoHwSwPcDto == null) {
            return NotFound();
        }

        var equipoPc = this.mapper.Map<EquipoPcRecursoHwSwPc>(equipoPcRecursoHwSwPcDto);
        equipoPc.Id_equipoFK = idEquiPc;
        equipoPc.Id_recursoHwSwPcFK = idRecurso;
        _UnitOfWork.EquipoPcRecursoHwSwPcs.Update(equipoPc);
        await _UnitOfWork.SaveAsync();

        return this.mapper.Map<EquipoPcRecursoHwSwPcDto>(equipoPc);        
    }

    //METODO DELETE (Eliminar un registro de la entidad de la Db)
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EquipoPcRecursoHwSwPcDto>> Delete(string idEquiPc, int idRecurso)
    {
        var equipoPc = await _UnitOfWork.EquipoPcRecursoHwSwPcs.GetByIdAsync(idEquiPc, idRecurso);
        
        if (equipoPc == null) {
            return NotFound();
        }

        _UnitOfWork.EquipoPcRecursoHwSwPcs.Remove(equipoPc);
        await _UnitOfWork.SaveAsync();

        return NoContent();
    }

}
