using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ClinicaMedica.Exceptions;
using ClinicaMedica.Localization;
using ClinicaMedica.Medicos;
using ClinicaMedica.Pacientes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp;
using Volo.Abp.BlobStoring;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Localization;

namespace ClinicaMedica.Tratamentos;

public class TratamentoManager : DomainService
{
  private readonly ITratamentoRepository _tratamentosRepository;
  private readonly IRepository<Medico, Guid> _medicoRepository;
  private readonly IRepository<Paciente, Guid> _pacienteRepository;
  private readonly IBlobContainer<TratamentoContainer> _blobContainer;
  private readonly IDistributedCache<TratamentoCacheItem, string> _cache;

  public TratamentoManager(ITratamentoRepository tratamentosRepository, IRepository<Paciente, Guid> pacienteRepository, IRepository<Medico, Guid> medicoRepository, IDistributedCache<TratamentoCacheItem, string> cache, IBlobContainer<TratamentoContainer> blobContainer)
  {
    _tratamentosRepository = tratamentosRepository;
    _pacienteRepository = pacienteRepository;
    _medicoRepository = medicoRepository;
    _cache = cache;
    _blobContainer = blobContainer;
  }

  public async Task<Tratamento> Criar(Guid medicoId, Guid pacienteId, List<string> sintomas, string diagnostico)
  {
    if (sintomas == null || sintomas.Count == 0)
    {
      throw new BusinessException(ExceptionConsts.TratamentoManager.SintomaInexistente);
    }

    var medico = await _medicoRepository.FindAsync(m => m.Id == medicoId);
    if (medico == null)
    {
      throw new BusinessException(ExceptionConsts.TratamentoManager.MedicoInexistente);
    }
    
    var paciente = await _pacienteRepository.FindAsync(p => p.Id == pacienteId);
    if (paciente == null)
    {
      throw new Exception(ExceptionConsts.TratamentoManager.PacienteInexistente);
    }
    
    if (paciente.Sexo != Sexo.Feminino && medico.Especialidade == Especialidade.Ginecologista)
    {
      throw new BusinessException(ExceptionConsts.TratamentoManager.EspecialidadeNaoPermitida);
    }

    if (paciente.Idade > 12 && medico.Especialidade == Especialidade.Pediatra)
    {
      throw new BusinessException(ExceptionConsts.TratamentoManager.EspecialidadeNaoPermitida);
    }
    
    var tratamento = new Tratamento(pacienteId, medicoId, sintomas, diagnostico);
    await _tratamentosRepository.InsertAsync(tratamento);
    
    return tratamento;
  }
  
  public async Task<TratamentoCacheItem?> GetTratamentoById(Guid id)
  {
    return await _cache.GetOrAddAsync(
      id.ToString(), //Cache key
      async () => await GetTratamentoFromDataBase(id),
      () => new DistributedCacheEntryOptions
      {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
      }
    );
  }

  private async Task<TratamentoCacheItem> GetTratamentoFromDataBase(Guid id)
  {
    var tratamento = await _tratamentosRepository.FirstOrDefaultAsync(x => x.Id == id);

    if (tratamento == null)
    {
      throw new BusinessException(ExceptionConsts.TratamentoManager.TratamentoInexistente); 
    }

    var tratamentoCacheItem = new TratamentoCacheItem
    {
      MedicoId = tratamento.MedicoId,
      PacienteId = tratamento.PacienteId,
      Sintomas = tratamento.Sintomas,
      Diagnostico = tratamento.Diagnostico,
      Status = tratamento.Status,
    };

    return tratamentoCacheItem;
  }

  public async Task AdicionarArquivoTratamento(Guid id, IFormFile arquivo, string nomeArquivo)
  {
    var tratamento = await _tratamentosRepository.FindAsync(t=>t.Id == id);
    
    var arquivoTratamento = new ArquivoTratamento(nomeArquivo);

    var ms = new MemoryStream();
    arquivo.CopyTo(ms);
    var fileBytes = ms.ToArray();
    
    await _blobContainer.SaveAsync(nomeArquivo, fileBytes, true);
    
  }
  
  private static LocalizableString L(string name)
  {
    return LocalizableString.Create<ClinicaMedicaResource>(name);
  }
}