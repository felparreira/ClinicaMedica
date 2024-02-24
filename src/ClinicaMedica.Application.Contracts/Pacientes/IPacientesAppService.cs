using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ClinicaMedica.Pacientes;

public interface IPacientesAppService : IApplicationService
{
    Task<PacienteDto> Create(CreateUpdatePacienteDto input);
    
    Task<PacienteDto> Get(Guid id);
    Task<List<PacienteDto>> GetAll(PagedAndSortedResultRequestDto input);
    Task Delete(Guid id);
}
    