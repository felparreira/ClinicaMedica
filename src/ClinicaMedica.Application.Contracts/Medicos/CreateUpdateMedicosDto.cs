using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Medicos;

public class CreateUpdateMedicosDto
{
    [Required] [StringLength(128)] public string Nome { get; set; }

    [Required] 
    [DataType(DataType.Date)] public DateTime DataNascimento { get; set; }

    [Required] 
    public Especialidade Especialidade { get; set; }

    [Required] 
    [StringLength(32)]
    public string Telefone { get; set; }
}