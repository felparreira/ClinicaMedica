using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Medicos;

public class MedicosAppService :
    CrudAppService<
        Medicos,
        MedicosDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateMedicosDto>,
    IMedicoAppServices
{
    public MedicosAppService(IRepository<Medicos, Guid> repository)
        : base(repository)
    {
        
    }
}