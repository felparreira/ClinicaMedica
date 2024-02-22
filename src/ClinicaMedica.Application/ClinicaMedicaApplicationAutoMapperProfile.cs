using AutoMapper;
using ClinicaMedica.Medicos;
using ClinicaMedica.Pacientes;
using ClinicaMedica.Tratamentos;

namespace ClinicaMedica;

public class ClinicaMedicaApplicationAutoMapperProfile : Profile
{
    public ClinicaMedicaApplicationAutoMapperProfile()
    {
        CreateMap<Pacientes.Paciente, PacienteDto>();
        CreateMap<CreateUpdatePacienteDto, Pacientes.Paciente>();
        
        CreateMap<Medico, MedicoDto>();
        CreateMap<CreateUpdateMedicoDto, Medico>();
        
        CreateMap<Tratamentos.Tratamento, TratamentoDto>();
        CreateMap<CreateUpdateTratamentoDto, Tratamentos.Tratamento>();
    }
}
