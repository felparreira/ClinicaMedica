using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaMedica.Exceptions;
using ClinicaMedica.Medicos;
using ClinicaMedica.Pacientes;
using Shouldly;
using Volo.Abp;
using Volo.Abp.Modularity;
using Xunit;

namespace ClinicaMedica.Tratamentos;

[Collection(ClinicaMedicaTestConsts.CollectionDefinitionName)]
public abstract class TratamentoManagerTest<TStartupModule> : ClinicaMedicaDomainTestBase<TStartupModule> where TStartupModule : IAbpModule

{
    private readonly ITratamentoRepository _tratamentosRepository;
    private readonly TratamentoManager _tratamentoManager;
    private readonly MedicoManager _medicoManager;
    private readonly PacienteManager _pacienteManager;


    public TratamentoManagerTest()
    {
        _tratamentosRepository = GetRequiredService<ITratamentoRepository>();
        _medicoManager = GetRequiredService<MedicoManager>();
        _pacienteManager = GetRequiredService<PacienteManager>();
        _tratamentoManager = GetRequiredService<TratamentoManager>();
    }

    [Fact]
    public async Task DeveCriarUmTratamento()
    {
        var pacienteId = Guid.NewGuid();
        string nomePaciente = "Felipe";
        string sobreNomePaciente = "Parreira";
        int idade = 33;
        string telefonePaciente = "31 99606-6790";
        
        var paciente = await _pacienteManager.Criar(pacienteId, nomePaciente, sobreNomePaciente, Sexo.Masculino, idade, telefonePaciente);

        var medicoId = Guid.NewGuid();
        string nomeMedico = "Carlos";
        string sobreNomeMedico = "Teixeira";
        string telefoneMedico = "31 99606-6790";
        string diagnostico = "Hipertensão arterial";
        
        var medico = await _medicoManager.Criar(medicoId, nomeMedico, sobreNomeMedico, Especialidade.Ortopedista, telefoneMedico);
 
        var tratamento = await _tratamentoManager.Criar(medico.Id, paciente.Id, new List<string>
        {
            "Dor de cabeça"
        },
            diagnostico);

        var tratamentoPersisted = await _tratamentosRepository.FindAsync(tratamento.Id);
        
        tratamentoPersisted?.MedicoId.ShouldBe(medico.Id);
        tratamentoPersisted?.PacienteId.ShouldBe(paciente.Id);
        tratamentoPersisted?.Sintomas.ShouldContain("Dor de cabeça");
        tratamentoPersisted?.Diagnostico.ShouldBe(diagnostico);
    }
    
    [Fact]
    public async Task NaoDeveCriarUmTratamento()
    {
        var pacienteId = Guid.NewGuid();
        string nomePaciente = "Ricardo";
        string sobreNomePaciente = "Moura";
        int idade = 21;
        string telefonePaciente = "31 92833-3452";
        
        var paciente = await _pacienteManager.Criar(pacienteId, nomePaciente, sobreNomePaciente, Sexo.Masculino, idade, telefonePaciente);

        var medicoId = Guid.NewGuid();
        string nomeMedico = "Carlos";
        string sobreNomeMedico = "Teixeira";
        string telefoneMedico = "31 99606-6790";
        
        var medico = await _medicoManager.Criar(medicoId, nomeMedico, sobreNomeMedico, Especialidade.Ginecologista, telefoneMedico);
 
        string diagnostico = "Hipertensão arterial";

        var exception = await Should.ThrowAsync<BusinessException>(async () =>
        {
            var tratamento = await _tratamentoManager.Criar(medico.Id, paciente.Id, new List<string>
                {
                    "Dor de cabeça"
                },
                diagnostico);
        });
        
       exception.Code.ShouldBe(ExceptionConsts.TratamentoManager.EspecialidadeNaoPermitida);
    }

}
    
