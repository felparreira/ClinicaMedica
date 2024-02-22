using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Tratamentos;

public class CreateUpdateTratamentoDto
{
    [Required]
    public Guid PacienteId { get; set; }
    
    [Required]
    public Guid MedicoId { get; set; }

    [Required] 
    public List<string> Sintomas { get; set; } 

    [Required] 
    [StringLength(128)] 
    public string Diagnostico { get; set; }

    [Required]
    public StatusTratamento Status { get; set; }
}