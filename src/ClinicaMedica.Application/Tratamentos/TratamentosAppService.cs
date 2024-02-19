using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Tratamentos;

[Authorize]
public class TratamentosAppService : ApplicationService, ITratamentosAppService
{
    private readonly IBlobContainer _blobContainer;
    public TratamentosAppService(IBlobContainer blobContainer)
    {
        _blobContainer = blobContainer;
    }

    public async Task<TratamentosDto> CriarTratamento (CreateUpdateTratamentosDto input)
    {
        return null;
    }
    
    public async Task<TratamentosDto> EditarTratamento (CreateUpdateTratamentosDto input)
    {
        return null;
    }

    public async Task<TratamentosDto> ListarTratamentos(CreateUpdateTratamentosDto input)
    {
        return null;
    }
    
    public async Task<TratamentosDto> ExcluirTratamento(Guid id)
    {
        return null;
    }
    
    public async Task AdicionarResultadoExame(byte[] arquivo)
    {
        await _blobContainer.SaveAsync("ResultadosExames", arquivo);
    }
    
}