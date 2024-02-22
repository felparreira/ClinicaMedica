using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaMedica.Medicos;
using ClinicaMedica.Pacientes;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Tratamentos;

[Authorize]
public class TratamentoAppService : ApplicationService, ITratamentoAppService
{
    private readonly IBlobContainer _blobContainer;
    private readonly TratamentoManager _tratamentoManager;
    private readonly ITratamentoRepository _tratamentoRepository;
    public TratamentoAppService(IBlobContainer blobContainer, TratamentoManager tratamentoManager, ITratamentoRepository tratamentoRepository)
    {
        _blobContainer = blobContainer;
        _tratamentoManager = tratamentoManager;
        _tratamentoRepository = tratamentoRepository;
    }

    public async Task<TratamentoDto> Create(CreateUpdateTratamentoDto input)
    {
        var tratamento = await _tratamentoManager.Criar(input.MedicoId, input.PacienteId, input.Sintomas);
        return ObjectMapper.Map<Tratamento,TratamentoDto>(tratamento);
    }

    public async Task<List<TratamentoDto>> GetAll(CreateUpdateTratamentoDto input)
    {
        var tratamentos = await _tratamentoRepository.GetListAsync();
        
        return ObjectMapper.Map<List<Tratamento>,List<TratamentoDto>>(tratamentos);
    }
    
    public async Task Delete(Guid id)
    {
        await _tratamentoRepository.DeleteAsync(t=> t.Id == id);
    }
    
    public async Task AdicionarResultadoExame(byte[] arquivo)
    {
        await _blobContainer.SaveAsync("ResultadosExames", arquivo);
    }
    
}