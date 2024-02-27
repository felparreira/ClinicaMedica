using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ClinicaMedica.Medicos;

public class CreateUpdateMedicoDto : IValidatableObject
{
    [Required] [StringLength(128)] public string Nome { get; set; }
    
    [Required] [StringLength(128)] public string sobreNome { get; set; }

    [Required] 
    public Especialidade Especialidade { get; set; }

    [Required] 
    [StringLength(32)]
    public string Telefone { get; set; }
    
    public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Nome == sobreNome)
        {
            yield return new ValidationResult("Nome e Sobrenome não podem ser iguais!", new[] { "Nome" });
        }
    }
}