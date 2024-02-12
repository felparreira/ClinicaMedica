using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Tratamentos;

public class TratamentosAppService :
    CrudAppService<
        Tratamentos,
        TratamentosDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateTratamentosDto>,
    ITratamentosAppService
{
    public TratamentosAppService(IRepository<Tratamentos, Guid> repository) :
        base(repository)
    {
        
    }
}