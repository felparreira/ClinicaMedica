using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ClinicaMedica.Medicos;

public class Medico : AuditedAggregateRoot<Guid>
{

    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public Especialidade Especialidade { get; set; }

    public string Telefone { get; set; }

    public Medico(string nome, DateTime dataNascimento, Especialidade especialidade, string telefone)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Especialidade = especialidade;
        Telefone = telefone;
    }
}
