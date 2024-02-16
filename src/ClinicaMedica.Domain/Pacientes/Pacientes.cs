using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ClinicaMedica.Pacientes;

public class Pacientes : AuditedAggregateRoot<Guid>
{
    public string Nome { get; set; }
    
    public string SobreNome { get; set; }

    public DateTime DataNascimento { get; set; }

    public Sexo Sexo { get; set; }

    public string Telefone { get; set; }
}


