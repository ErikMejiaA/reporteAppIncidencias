namespace Dominio.Interfaces;
public interface IUnitOfWorkInterface
{
    //cargamos cada una de las interfaces creadas 
    IAreaIncidenciaInterface AreaIncidencias {get; }
    IArlInterface Arl { get; }
    ICategoriaInterface Categorias { get; }
    ICiudadInterface Ciudades { get; }
    IDepartamentoInterface Departamentos { get; }
    IDireccionInterface Direcciones { get; }
    IEpsInterface Eps { get; }
    IEquipoPcInterface EquipoPcs { get; }
    IEquipoPcRecursoHwSwPcInterface EquipoPcRecursoHwSwPcs { get; }
    IEstadoIncidenciaInterface EstadoIncidencias { get; }
    IGeneroInterface Generos { get; }
    IIncidenciaInterface Incidencias { get; }
    IPaisInterface Paises { get; }
    IPersonaInterface Personas { get; } 
    IPersonaEmailInterface PersonaEmails { get; }
    IPersonaTelefonoMovilInterface PersonaTelefonoMoviles { get; }
    IPuestoInterface Puestos { get; }
    IRecursoHwSwPcInterface RecursoHwSwPcs { get; }
    ISalonInterface Salones { get; }
    ITipoEmailInterface TipoEmails { get; }
    ITipoNivelIncidenciaInterface TipoNivelIncidencias { get; }
    IRolInterface Roles { get; }
    ITipoSangreInterface TiposSangre { get; }
    ITipoTelefonoMovilInterface TipoTelefonoMoviles { get; }
    IUsuarioInterface Usuarios { get; }
    IUsuariosRolesInterface UsuariosRoles { get; }

    Task<int> SaveAsync();

}
