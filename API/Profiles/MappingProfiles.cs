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
        CreateMap<EstadoIncidencia, EstadoIncidenciaDTo>().ReverseMap();
        CreateMap<Genero, GeneroDto>().ReverseMap();
        CreateMap<Genero, GeneroPersonaDto>().ReverseMap();
        CreateMap<Incidencia, IncidenciaDto>().ReverseMap();
        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Pais, PaisPorDepDto>().ReverseMap();
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<PersonaEmail, PersonaEmailDto>().ReverseMap();
        CreateMap<PersonaTelefonoMovil, PersonaTelefonoMovilDto>().ReverseMap();
        CreateMap<Puesto, PuestoDto>().ReverseMap();
        CreateMap<RecursoHwSwPc, RecursoHwSwPcDto>().ReverseMap();
        CreateMap<Salon, SalonDto>().ReverseMap();
        CreateMap<TipoEmail, TipoEmailDto>().ReverseMap();
        CreateMap<TipoNivelIncidencia, TipoNivelIncidenciaDto>().ReverseMap();
        CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();
        CreateMap<TipoSangre, TipoSangreDto>().ReverseMap();
        CreateMap<TipoTelefonoMovil, TipoTelefonoMovilDto>().ReverseMap();
    }
}
