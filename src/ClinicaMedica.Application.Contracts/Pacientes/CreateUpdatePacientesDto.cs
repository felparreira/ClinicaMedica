using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaMedica.Pacientes;

public class CreateUpdatePacientesDto
{
    [Required] 
    [StringLength(128)] 
    public string Nome { get; set; } = string.Empty;

    [Required] public Sexo Sexo { get; set; } = Sexo.Indefindo;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; } = DateTime.Now;

    [Required] 
    [StringLength(32)]
    public string Telefone { get; set; } = string.Empty;
}