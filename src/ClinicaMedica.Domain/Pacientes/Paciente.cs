using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ClinicaMedica.Pacientes;

public class Paciente : AuditedAggregateRoot<Guid>
{
    public string Nome { get; set; }
    
    public string SobreNome { get; set; }

    public DateTime DataNascimento { get; set; }

    public Sexo Sexo { get; set; }

    public string Telefone { get; set; }

    public Paciente(string nome, string sobreNome, DateTime dataNascimento, Sexo sexo, string telefone)
    {
        Nome = nome;
        SobreNome = sobreNome;
        DataNascimento = dataNascimento;
        Sexo = sexo;
        Telefone = telefone;
    }
}


