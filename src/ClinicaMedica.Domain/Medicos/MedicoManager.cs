using System;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Volo.Abp.Domain.Services;

namespace ClinicaMedica.Medicos;

public class MedicoManager : DomainService
{
    private readonly IMedicoRepository _medicoRepository;

    public MedicoManager(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public async Task<Medico> Criar(Guid id, string nome, string sobreNome, Especialidade especialidade,
        string telefone)
    {
        var medico = new Medico(nome, sobreNome, especialidade, telefone);
        await _medicoRepository.InsertAsync(medico);
        return medico;
    }
}