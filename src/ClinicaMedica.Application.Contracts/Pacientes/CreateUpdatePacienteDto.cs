using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ClinicaMedica.Pacientes;

public class CreateUpdatePacienteDto : PagedAndSortedResultRequestDto, IValidatableObject
{
    [Required] 
    [StringLength(128)] 
    public string Nome { get; set; }
    
    [Required] 
    [StringLength(128)] 
    public string SobreNome { get; set; }

    [Required] public Sexo Sexo { get; set; }

    [Required]
    [MaxLength(3)]
    public int Idade { get; set; }
    
    [StringLength(32)]
    public string Telefone { get; set; }

    public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Nome == SobreNome)
        {
            yield return new ValidationResult("Nome e Sobrenome não podem ser iguais!", new[] { "Nome" });
        }
        
        if (Idade <= 0)
        {
            yield return new ValidationResult("Idade não pode ser menor ou igual a zero!", new[] { "Idade" });
        }
    }
}