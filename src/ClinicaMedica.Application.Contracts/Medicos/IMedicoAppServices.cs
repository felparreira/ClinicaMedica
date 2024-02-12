using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ClinicaMedica.Medicos;

public interface IMedicoAppServices :
    ICrudAppService<
        MedicosDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateMedicosDto>

{
}