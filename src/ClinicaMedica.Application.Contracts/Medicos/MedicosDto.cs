using System;
using Volo.Abp.Application.Dtos;

namespace ClinicaMedica.Medicos;

public class MedicosDto : AuditedEntityDto<Guid>
{
    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public Especialidade Especialidade { get; set; }

    public string Telefone { get; set; }
}