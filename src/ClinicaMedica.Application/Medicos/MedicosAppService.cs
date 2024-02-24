using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaMedica.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Medicos;

[Authorize]
public class MedicosAppService : ApplicationService, IMedicoAppServices
{
    private readonly MedicoManager _medicoManager;
    private readonly IMedicoRepository _medicoRepository;

    public MedicosAppService(MedicoManager medicoManager, IMedicoRepository medicoRepository)
    {
        _medicoManager = medicoManager;
        _medicoRepository = medicoRepository;
    }
    
    public async Task<MedicoDto> Create(CreateUpdateMedicoDto input)
    {

        var paciente = await _medicoManager.Criar(new Guid(), input.Nome, input.sobreNome, input.Especialidade, input.Telefone);
        return ObjectMapper.Map<Medico, MedicoDto>(paciente);
    }

    public async Task<MedicoDto> Get(Guid id)
    {
        var medico = await _medicoRepository.GetAsync(m=> m.Id == id);
        
        return ObjectMapper.Map<Medico, MedicoDto>(medico);
    }
    public async Task<List<MedicoDto>> GetAll(PagedAndSortedResultRequestDto input)
    {
        var medico = await _medicoRepository.GetListAsync();
        
        return ObjectMapper.Map<List<Medico>,List<MedicoDto>>(medico);
    }
    
    [Authorize(ClinicaMedicaPermissions.Pacientes.Delete)]
    public async Task Delete(Guid id)
    {
        await _medicoRepository.DeleteAsync(t=> t.Id == id);
    }
}