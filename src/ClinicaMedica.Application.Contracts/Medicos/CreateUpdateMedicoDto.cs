using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ClinicaMedica.Medicos;

public class CreateUpdateMedicoDto : PagedAndSortedResultRequestDto
{
    [Required] [StringLength(128)] public string Nome { get; set; }
    
    [Required] [StringLength(128)] public string sobreNome { get; set; }

    [Required] 
    public Especialidade Especialidade { get; set; }

    [Required] 
    [StringLength(32)]
    public string Telefone { get; set; }
}