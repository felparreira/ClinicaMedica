using System;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Pacientes;

public interface IPacienteRepository : IRepository<Paciente, Guid>
{
    
}