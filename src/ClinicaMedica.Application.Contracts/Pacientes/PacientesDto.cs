using System;
using Volo.Abp.Application.Dtos;

namespace ClinicaMedica.Pacientes;

public class PacientesDto : AuditedEntityDto<Guid>
{
    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public Sexo Sexo { get; set; }

    public string Telefone { get; set; }
}