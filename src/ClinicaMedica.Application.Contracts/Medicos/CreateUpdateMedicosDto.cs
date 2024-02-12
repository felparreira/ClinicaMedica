using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Medicos;

public class CreateUpdateMedicosDto
{
    [Required] [StringLength(128)] public string Nome { get; set; } = String.Empty;

    [Required] 
    [DataType(DataType.Date)] public DateTime DataNascimento { get; set; } = DateTime.Now;

    [Required] 
    public Especialidade Especialidade { get; set; } = Especialidade.ClinicoGeral;

    [Required] 
    [StringLength(32)]
    public string Telefone { get; set; } = String.Empty;
}