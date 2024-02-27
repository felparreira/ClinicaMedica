using AutoMapper;
using ClinicaMedica.Medicos;
using ClinicaMedica.Pacientes;
using ClinicaMedica.Tratamentos;

namespace ClinicaMedica;

public class ClinicaMedicaApplicationAutoMapperProfile : Profile
{
    public ClinicaMedicaApplicationAutoMapperProfile()
    {
        CreateMap<Paciente, PacienteDto>();
        CreateMap<CreateUpdatePacienteDto, Paciente>();
        
        CreateMap<Medico, MedicoDto>();
        CreateMap<CreateUpdateMedicoDto, Medico>();
        
        CreateMap<Tratamento, TratamentoDto>();
        CreateMap<CreateUpdateTratamentoDto, Tratamento>();
        CreateMap<TratamentoCacheItem, TratamentoDto>();
    }
}
