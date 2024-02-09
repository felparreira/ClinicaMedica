using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ClinicaMedica.Medicos;

public class Medicos : AuditedAggregateRoot<Guid>
{
    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public Especialidade Especialidade { get; set; }

    public string Telefone { get; set; }
}
