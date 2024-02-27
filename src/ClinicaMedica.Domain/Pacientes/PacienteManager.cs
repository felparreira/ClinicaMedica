using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Services;

namespace ClinicaMedica.Pacientes;

public class PacienteManager : DomainService
{
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteManager(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<Paciente> Criar(Guid id, string nome, string sobreNome, Sexo sexo, int idade,
        string telefone)
    {
        var paciente = new Paciente(nome, sobreNome, idade, sexo, telefone); 
        await _pacienteRepository.InsertAsync(paciente);
        
        return paciente;
    }
    
    public Paciente Atualizar(Paciente paciente, string nome, string sobreNome, Sexo sexo, int idade,
        string telefone)
    {
        paciente.Nome = nome;
        paciente.SobreNome = sobreNome;
        paciente.Sexo = sexo;
        paciente.Idade = idade;
        paciente.Telefone = telefone;

        return paciente;
    }
}