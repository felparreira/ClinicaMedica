using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ClinicaMedica.Medicos;

public interface IMedicoAppServices : IApplicationService
{
    Task<MedicoDto> Create(CreateUpdateMedicoDto input);
    Task<MedicoDto> Get(Guid id);
    Task<List<MedicoDto>> GetAll(PagedAndSortedResultRequestDto input);
    Task Delete(Guid id);
}
