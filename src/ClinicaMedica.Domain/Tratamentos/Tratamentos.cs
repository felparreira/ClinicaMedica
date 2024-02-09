using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace ClinicaMedica.Tratamentos;

public class Tratamentos : AuditedAggregateRoot<Guid>
{
    public Guid PacienteId { get; set; }
    
    public Guid MedicoId { get; set; }
    
    public List<string> Sintomas { get; set; }
    
    public string Diagnostico { get; set; }
    
    public StatusTratamento Status { get; set; }
}