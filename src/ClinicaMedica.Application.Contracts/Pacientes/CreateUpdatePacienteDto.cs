using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Pacientes;

public class CreateUpdatePacienteDto : IValidatableObject
{
    [Required] 
    [StringLength(128)] 
    public string Nome { get; set; }
    
    [Required] 
    [StringLength(128)] 
    public string SobreNome { get; set; }

    [Required] public Sexo Sexo { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    
    [StringLength(32)]
    public string Telefone { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Nome == SobreNome)
        {
            yield return new ValidationResult("Nome e Sobrenome não podem ser iguais!", new[] { "Nome" });
        }
    }
}