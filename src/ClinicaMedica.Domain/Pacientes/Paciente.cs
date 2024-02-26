using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ClinicaMedica.Pacientes;

public class Paciente : AuditedAggregateRoot<Guid>
{
    public string Nome { get; set; }
    
    public string SobreNome { get; set; }

    public int Idade { get; set; }

    public Sexo Sexo { get; set; }

    public string Telefone { get; set; }

    public Paciente(string nome, string sobreNome, int idade, Sexo sexo, string telefone)
    {
        Nome = nome;
        SobreNome = sobreNome;
        Idade = idade;
        Sexo = sexo;
        Telefone = telefone;
    }
}


