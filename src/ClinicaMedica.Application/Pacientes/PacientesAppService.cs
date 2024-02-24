using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaMedica.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ClinicaMedica.Pacientes;

[Authorize]
public class PacientesAppService : ApplicationService, IPacientesAppService
{
    private readonly PacienteManager _pacienteManager;
    private readonly IPacienteRepository _pacienteRepository;

    public PacientesAppService(PacienteManager pacienteManager, IPacienteRepository pacienteRepository)
    {
        _pacienteManager = pacienteManager;
        _pacienteRepository = pacienteRepository;
    }
    
    public async Task<PacienteDto> Create(CreateUpdatePacienteDto input)
    {

        var paciente = await _pacienteManager.Criar(new Guid(), input.Nome, input.SobreNome, input.Sexo, input.DataNascimento,
            input.Telefone);
        return ObjectMapper.Map<Paciente, PacienteDto>(paciente);
    }

    public async Task<PacienteDto> Get(Guid id)
    {
        var paciente = await _pacienteRepository.GetAsync(p=> p.Id == id);
        
        return ObjectMapper.Map<Paciente, PacienteDto>(paciente);
    }
    public async Task<List<PacienteDto>> GetAll(PagedAndSortedResultRequestDto input)
    {
        var pacientes = await _pacienteRepository.GetListAsync();
        
        return ObjectMapper.Map<List<Paciente>,List<PacienteDto>>(pacientes);
    }
    
    [Authorize(ClinicaMedicaPermissions.Pacientes.Delete)]
    public async Task Delete(Guid id)
    {
        await _pacienteRepository.DeleteAsync(t=> t.Id == id);
    }
}