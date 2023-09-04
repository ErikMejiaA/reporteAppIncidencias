using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;
using Persistencia.Data.Configuration;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWorkInterface, IDisposable
{
    //generamos las varables de los repositorios creados 

    private readonly ReporteAppIncidenciasContext _context;

    private AreaIncidenciaRepository ? _areaIncidencias;
    private ArlRepository ? _arl;
    private CategoriaRepository ? _categorias;
    private CiudadRepository ? _ciudades;
    private DepartamentoRepository ? _departamentos;
    private DireccionRepository ? _direcciones;
    private EpsRepository ? _eps;
    private EquipoPcRecursoHwSwPcRepository ? _equipoPcRecursoHwSwPcs;
    private EquipoPcRepository ? _equipoPcs;
    private EstadoIncidenciaRepository ? _estadoIncidencias;
    private GeneroRepository ? _generos;
    private IncidenciaRepository ? _incidencias;
    private PaisRepository ? _paises;
    private PersonaEmailRepository ? _personaEmails;
    private PersonaRepository ? _personas;
    private PersonaTelefonoMovilRepository ? _personaTelefonoMoviles;
    private PuestoRepository ? _puestos;
    private RecursoHwSwPcRepository ? _recursoHwSwPcs;
    private SalonRepository ? _salones;
    private TipoEmailRepository ? _tipoEmails;
    private TipoNivelIncidenciaRepository ? _tipoNivelIncidencias;
    private RolRepository ? _roles;
    private TipoSangreRepository ? _tiposSangre;
    private TipoTelefonoMovilRepository ? _tipoTelefonoMoviles;
    private UsuarioRepository ? _usuarios;
    private UsuariosRolesRepository ? _usuariosRoles;

    public UnitOfWork(ReporteAppIncidenciasContext context)
    {
        _context = context;
    }

    public IAreaIncidenciaInterface AreaIncidencias
    {
        get
        {
            if (_areaIncidencias == null) {
                _areaIncidencias = new AreaIncidenciaRepository(_context);
            }
            return _areaIncidencias;
        }
    }

    public IArlInterface Arl
    {
        get
        {
            if (_arl == null) {
                _arl = new ArlRepository(_context);
            }
            return _arl;
        }
    }

    public ICategoriaInterface Categorias
    {
        get
        {
            if (_categorias == null) {
                _categorias = new CategoriaRepository(_context);
            }
            return _categorias;
        }
    }

    public ICiudadInterface Ciudades
    {
        get
        {
            if (_ciudades == null) {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }

    public IDepartamentoInterface Departamentos 
    {
        get
        {
            if (_departamentos == null) {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }

    public IDireccionInterface Direcciones
    {
        get
        {
            if (_direcciones == null) {
                _direcciones = new DireccionRepository(_context);
            }
            return _direcciones;
        }
    }

    public IEpsInterface Eps
    {
        get
        {
            if (_eps == null) {
                _eps = new EpsRepository(_context);
            }
            return _eps;
        }
    }

    public IEquipoPcInterface EquipoPcs 
    {
        get
        {
            if (_equipoPcs == null) {
                _equipoPcs = new EquipoPcRepository(_context);
            }
            return _equipoPcs;

        }
    }

    public IEquipoPcRecursoHwSwPcInterface EquipoPcRecursoHwSwPcs 
    {
        get
        {
            if (_equipoPcRecursoHwSwPcs == null) {
                _equipoPcRecursoHwSwPcs = new EquipoPcRecursoHwSwPcRepository(_context);
            }
            return _equipoPcRecursoHwSwPcs;
        }
    }

    public IEstadoIncidenciaInterface EstadoIncidencias
    {
        get
        {
            if (_estadoIncidencias == null) { 
                _estadoIncidencias = new EstadoIncidenciaRepository(_context);
            }
            return _estadoIncidencias;
        }
    }

    public IGeneroInterface Generos
    {
        get
        {
            if (_generos == null) {
                _generos = new GeneroRepository(_context);
            }
            return _generos;
        }
    }

    public IIncidenciaInterface Incidencias
    {
        get
        {
            if (_incidencias == null) { 
                _incidencias = new IncidenciaRepository(_context);
            }
            return _incidencias;
        }
    }

    public IPaisInterface Paises
    {
        get
        {
            if (_paises == null) {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }

    public IPersonaInterface Personas
    {
        get
        {
            if (_personas == null) {
                _personas = new PersonaRepository(_context);
            }
            return _personas;

        }
    }

    public IPersonaEmailInterface PersonaEmails
    {
        get
        {
            if (_personaEmails == null) {
                _personaEmails = new PersonaEmailRepository(_context);
            }
            return _personaEmails;
        }
    }

    public IPersonaTelefonoMovilInterface PersonaTelefonoMoviles 
    {
        get
        {
            if (_personaTelefonoMoviles == null) {
                _personaTelefonoMoviles = new PersonaTelefonoMovilRepository(_context);
            }
            return _personaTelefonoMoviles;

        }
    }

    public IPuestoInterface Puestos
    {
        get
        {
            if (_puestos == null) {
                _puestos =new PuestoRepository(_context);
            }
            return _puestos;
        }
    }

    public IRecursoHwSwPcInterface RecursoHwSwPcs
    {
        get
        {
            if (_recursoHwSwPcs == null) {
                _recursoHwSwPcs = new RecursoHwSwPcRepository(_context);
            }
            return _recursoHwSwPcs;
        }
    }

    public ISalonInterface Salones 
    {
        get
        {
            if (_salones == null) {
                _salones = new SalonRepository(_context);
            }
            return _salones;
        }
    }

    public ITipoEmailInterface TipoEmails
    {
        get
        {
            if (_tipoEmails == null) {
                _tipoEmails = new TipoEmailRepository(_context);
            }
            return _tipoEmails;
        }
    }

    public ITipoNivelIncidenciaInterface TipoNivelIncidencias
    {
        get
        {
            if (_tipoNivelIncidencias == null) {
                _tipoNivelIncidencias = new TipoNivelIncidenciaRepository(_context);
            }
            return _tipoNivelIncidencias;
        }
    }

    public IRolInterface Roles
    {
        get
        {
            if (_roles == null) {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public ITipoSangreInterface TiposSangre
    {
        get
        {
            if (_tiposSangre == null) {
                _tiposSangre = new TipoSangreRepository(_context);
            }
            return _tiposSangre;
        }
    }

    public ITipoTelefonoMovilInterface TipoTelefonoMoviles 
    {
        get
        {
            if (_tipoTelefonoMoviles == null) {
                _tipoTelefonoMoviles = new TipoTelefonoMovilRepository(_context);
            }
            return _tipoTelefonoMoviles;
        }
    }

    public IUsuarioInterface Usuarios
    {
        get
        {
            if (_usuarios == null) {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public IUsuariosRolesInterface UsuariosRoles
    {
        get
        {
            if (_usuariosRoles == null) {
                _usuariosRoles = new UsuariosRolesRepository(_context);
            }
            return _usuariosRoles;
        }
    }


    public void Dispose()
    {
        _context.Dispose(); //liberar menoria 
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync(); //guardar las actualizaciones en la Db
    }
}
