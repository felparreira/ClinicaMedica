using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaMedica.Medicos;
using ClinicaMedica.MongoDB.Tratamentos;
using ClinicaMedica.Pacientes;
using NSubstitute;
using Shouldly;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace ClinicaMedica.Tratamentos;

public sealed class TratamentoManagerTest : ClinicaMedicaDomainTestBase<ClinicaMedicaDomainTestModule>
{
    private readonly ITratamentoRepository _tratamentosRepository;
    private readonly TratamentoManager _tratamentoManager;
    private readonly IMedicoAppServices _medicoAppServices;
    private readonly IPacientesAppService _pacientesAppService;


    public TratamentoManagerTest()
    {
        _tratamentosRepository = GetRequiredService<ITratamentoRepository>();
        _medicoAppServices = GetRequiredService<IMedicoAppServices>();
        _pacientesAppService = GetRequiredService<IPacientesAppService>();
        _tratamentoManager = GetRequiredService<TratamentoManager>();
    }

    [Fact]
    public async Task ShouldCreateATreatment()
    {
        var pacienteId = Guid.NewGuid()
            
        var fakePaciente = Substitute.For<IPacientesAppService>();
        fakePaciente.GetListAsync(pacienteId).Returns();
        
        var paciente = await _pacientesAppService.CreateAsync(new CreateUpdatePacienteDto()
        {
            DataNascimento = DateTime.Now,
            Nome = "Felipe",
            Sexo = Sexo.Masculino,
            SobreNome = "Parreira",
            Telefone = "31 99999-9999"
        });
        
        var medico = await _medicoAppServices.CreateAsync(new CreateUpdateMedicoDto()
        {
            DataNascimento = DateTime.Now,
            Nome = "Felipe",
            Especialidade = Especialidade.Dermatologista,
            Telefone = "31 99999-9999"
        });
        
        var tratamento = await _tratamentoManager.Criar(medico.Id, paciente.Id, new List<string>
        {
            "Dor na cabeça"
        });

        var tratamentoPersisted = await _tratamentosRepository.FindAsync(tratamento.Id);
        
        tratamentoPersisted.MedicoId.ShouldBe(medico.Id);
        tratamentoPersisted.PacienteId.ShouldBe(paciente.Id);
        tratamentoPersisted.Sintomas.ShouldContain("Dor na cabeça");
    }

}
    
