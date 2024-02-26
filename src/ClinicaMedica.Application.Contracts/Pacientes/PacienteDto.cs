using System;
using Volo.Abp.Application.Dtos;

namespace ClinicaMedica.Pacientes;

public class PacienteDto : AuditedEntityDto<Guid>
{
    public string Nome { get; set; }
    
    public string SobreNome { get; set; }

    public int Idade { get; set; }

    public Sexo Sexo { get; set; }

    public string Telefone { get; set; }
}