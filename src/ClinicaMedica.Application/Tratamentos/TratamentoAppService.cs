using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaMedica.Permissions;
using ClinicaMedica.Tratamentos.Events.Eto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.EventBus.Local;

namespace ClinicaMedica.Tratamentos;

[Authorize]
public class TratamentoAppService : ApplicationService, ITratamentoAppService
{
    
    private readonly TratamentoManager _tratamentoManager;
    private readonly ITratamentoRepository _tratamentoRepository;
    private readonly ILocalEventBus _localEventBus;
    public TratamentoAppService(TratamentoManager tratamentoManager, ITratamentoRepository tratamentoRepository, ILocalEventBus localEventBus)
    {
        _tratamentoManager = tratamentoManager;
        _tratamentoRepository = tratamentoRepository;
        _localEventBus = localEventBus;
    }

    [Authorize(ClinicaMedicaPermissions.Tratamentos.Create)]
    public async Task<TratamentoDto> Create(CreateUpdateTratamentoDto input)
    {
        var tratamento = await _tratamentoManager.Criar(input.MedicoId, input.PacienteId, input.Sintomas);
        return ObjectMapper.Map<Tratamento,TratamentoDto>(tratamento);
    }

    [Authorize(ClinicaMedicaPermissions.Tratamentos.GetAll)]
    public async Task<List<TratamentoDto>> GetAll(PagedAndSortedResultRequestDto input)
    {
        var tratamentos = await _tratamentoRepository.GetListAsync();
        
        return ObjectMapper.Map<List<Tratamento>,List<TratamentoDto>>(tratamentos);
    }
    
    [Authorize(ClinicaMedicaPermissions.Tratamentos.Delete)]
    public async Task Delete(Guid id)
    {
        await _tratamentoRepository.DeleteAsync(t=> t.Id == id);
    }
    
    [Authorize(ClinicaMedicaPermissions.Tratamentos.Update)]
    public async Task AdicionarArquivoTratamento(Guid id, IFormFile arquivo, string nomeArquivo)
    {
        await _tratamentoManager.AdicionarArquivoTratamento(id, arquivo, nomeArquivo);
        
        await _localEventBus.PublishAsync(new AtualizaStatusTratamentoEto
        {
            Id = id
        });
    }
    
}