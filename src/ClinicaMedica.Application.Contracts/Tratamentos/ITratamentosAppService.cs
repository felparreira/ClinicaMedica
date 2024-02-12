using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ClinicaMedica.Tratamentos;

public interface ITratamentosAppService :
    ICrudAppService<
        TratamentosDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateTratamentosDto>
{
    
}