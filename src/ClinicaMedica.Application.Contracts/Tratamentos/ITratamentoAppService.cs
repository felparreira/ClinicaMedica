using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ClinicaMedica.Tratamentos;

public interface ITratamentoAppService : IApplicationService
{
    Task<TratamentoDto> Create(CreateUpdateTratamentoDto input);
    //Task<TratamentoDto> Editar(CreateUpdateTratamentoDto input);
    Task<List<TratamentoDto>> GetAll(CreateUpdateTratamentoDto id);
    Task Delete(Guid id);
    Task AdicionarResultadoExame(byte[] arquivo);
}