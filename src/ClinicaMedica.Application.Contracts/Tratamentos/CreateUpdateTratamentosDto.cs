using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Tratamentos;

public class CreateUpdateTratamentosDto
{
    [Required]
    public Guid PacienteId { get; set; } = Guid.Empty;
    
    [Required]
    public Guid MedicoId { get; set; } = Guid.Empty;

    [Required] 
    public List<string> Sintomas { get; set; } = new List<string> { string.Empty }; 

    [Required] 
    [StringLength(128)] 
    public string Diagnostico { get; set; } = string.Empty;

    [Required] 
    public StatusTratamento Status { get; set; } = StatusTratamento.Pendente;
}