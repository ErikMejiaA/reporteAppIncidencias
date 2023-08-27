using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CReamos el mapeo de las entidades a los Dtos
        CreateMap<AreaIncidencia, AreaIncidenciaDto>().ReverseMap();
        CreateMap<AreaIncidencia, AreaIncidenciaSalonDto>().ReverseMap();
        
        CreateMap<Arl, ArlDto>().ReverseMap();
        CreateMap<Arl, ArlPorPersonaDto>().ReverseMap();
        
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
        CreateMap<Categoria, CategoriaIncideRecurDto>().ReverseMap();
        
        CreateMap<Ciudad, CiudadDto>().ReverseMap();
        CreateMap<Ciudad, CiudadPersonaDto>().ReverseMap();
        
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoCiudadDto>().ReverseMap();
        
        CreateMap<Direccion, DireccionDto>().ReverseMap();
        
        CreateMap<Eps, EpsDto>().ReverseMap();
        CreateMap<Eps, EpsPersonaDto>().ReverseMap();
        
        CreateMap<EquipoPc, EquipoPcDto>().ReverseMap();
        CreateMap<EquipoPc, EquipoPcRecusosDto>().ReverseMap();
        
        CreateMap<EquipoPcRecursoHwSwPc, EquipoPcRecursoHwSwPcDto>().ReverseMap();
        
        CreateMap<EstadoIncidencia, EstadoIncidenciaDto>().ReverseMap();
        
        CreateMap<Genero, GeneroDto>().ReverseMap();
        CreateMap<Genero, GeneroPersonaDto>().ReverseMap();
        
        CreateMap<Incidencia, IncidenciaDto>().ReverseMap();
        
        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Pais, PaisPorDepDto>().ReverseMap();
        
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<Persona, PersonaListTodoDto>().ReverseMap();
        
        CreateMap<PersonaEmail, PersonaEmailDto>().ReverseMap();
        
        CreateMap<PersonaTelefonoMovil, PersonaTelefonoMovilDto>().ReverseMap();
        
        CreateMap<Puesto, PuestoDto>().ReverseMap();
        CreateMap<Puesto, PuestoPorIncidenciaDto>().ReverseMap();

        CreateMap<RecursoHwSwPc, RecursoHwSwPcDto>().ReverseMap();
        CreateMap<RecursoHwSwPc, RecursoHwSwXEquipoPcDto>().ReverseMap();

        CreateMap<Salon, SalonDto>().ReverseMap();
        CreateMap<Salon, SalonXInciXPuestoDto>().ReverseMap();

        CreateMap<TipoEmail, TipoEmailDto>().ReverseMap();
        CreateMap<TipoEmail, TipoEmailXPersonaDto>().ReverseMap();
        
        CreateMap<TipoNivelIncidencia, TipoNivelIncidenciaDto>().ReverseMap();
        CreateMap<TipoNivelIncidencia, TipoNivelIncidenXIncidenciaDto>().ReverseMap();

        CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();
        CreateMap<TipoPersona, TipoPersonaXpersonaDto>().ReverseMap();

        CreateMap<TipoSangre, TipoSangreDto>().ReverseMap();
        CreateMap<TipoSangre, TipoSangreXpersonaDto>().ReverseMap();

        CreateMap<TipoTelefonoMovil, TipoTelefonoMovilDto>().ReverseMap();
        CreateMap<TipoTelefonoMovil, TipoTeleMoviXpersonaTeleMoviDto>().ReverseMap();
    }
}
