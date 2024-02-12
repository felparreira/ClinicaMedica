using AutoMapper;
using ClinicaMedica.Medicos;
using ClinicaMedica.Pacientes;
using ClinicaMedica.Tratamentos;

namespace ClinicaMedica;

public class ClinicaMedicaApplicationAutoMapperProfile : Profile
{
    public ClinicaMedicaApplicationAutoMapperProfile()
    {
        CreateMap<Pacientes.Pacientes, PacientesDto>();
        CreateMap<CreateUpdatePacientesDto, Pacientes.Pacientes>();
        
        CreateMap<Medicos.Medicos, MedicosDto>();
        CreateMap<CreateUpdateMedicosDto, Medicos.Medicos>();
        
        CreateMap<Tratamentos.Tratamentos, TratamentosDto>();
        CreateMap<CreateUpdateTratamentosDto, Tratamentos.Tratamentos>();
    }
}
