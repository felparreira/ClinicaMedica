using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ClinicaMedica.Medicos;

public class Medico : AuditedAggregateRoot<Guid>
{

    public string Nome { get; set; }

    public string SobreNome { get; set; }

    public Especialidade Especialidade { get; set; }

    public string Telefone { get; set; }

    public Medico(string nome, string sobreNome, Especialidade especialidade, string telefone)
    {
        Nome = nome;
        SobreNome = sobreNome;
        Especialidade = especialidade;
        Telefone = telefone;
    }
}
