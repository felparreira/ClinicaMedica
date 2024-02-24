using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ClinicaMedica.Pacientes;

public class PacienteManager : DomainService
{
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteManager(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<Paciente> Criar(Guid id, string nome, string sobreNome, Sexo sexo, DateTime dataNascimento,
        string telefone)
    {
        var paciente = new Paciente(nome, sobreNome, dataNascimento, sexo, telefone); 
        await _pacienteRepository.InsertAsync(paciente);
        return paciente;
    }
}