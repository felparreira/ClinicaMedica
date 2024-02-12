using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ClinicaMedica.Pacientes;

public interface IPacientesAppService :
    ICrudAppService<
        PacientesDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePacientesDto>
{
    
}