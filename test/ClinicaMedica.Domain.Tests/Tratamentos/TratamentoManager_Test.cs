using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaMedica.Exceptions;
using ClinicaMedica.Medicos;
using ClinicaMedica.Pacientes;
using ClinicaMedica.Permissions;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace ClinicaMedica.Tratamentos;

public sealed class TratamentoManager_Test : ClinicaMedicaDomainTestBase<ClinicaMedicaDomainModule>
{
    private readonly TratamentoManager _tratamentoManager;
    private readonly ITratamentoRepository _tratamentosRepository;
    private readonly IRepository<Paciente, Guid> _pacienteRepository;
    private readonly IRepository<Medico, Guid> _medicoRepository;

    [Fact]
    public async Task ShouldCreateATreatment()
    {
        var tratamento = new CreateUpdateTratamentoDto()
        {
            PacienteId = new Guid("84f810dc-74dd-ecf0-63c0-3a10babb4d73"),
            MedicoId = new Guid("7eccb77e-4f6b-3e06-1663-3a10ddebcf43"),
            Sintomas = new List<string> { "Febre","Vômito", "Diarréia" },
            Diagnostico = "Virose",
            Status = 0
        };
        
    }

    [Fact]
    public async Task ShouldNotCreateATreatmentWithoutADoctor()
    {
        var tratamento = new CreateUpdateTratamentoDto()
        {
            PacienteId = new Guid("84f810dc-74dd-ecf0-63c0-3a10babb4d73"),
            MedicoId = new Guid("7eccb77e-4f6b-3e06-1663-3a10ddebcf41"),
            Sintomas = new List<string> { "Febre","Vômito", "Diarréia" },
            Diagnostico = "Virose",
            Status = 0
        };
    }

    [Fact]
    public async Task ShouldNotCreateATreatmentWithoutAPatience()
    {
        var tratamento = new CreateUpdateTratamentoDto()
        {
            PacienteId = new Guid("84f810dc-74dd-ecf0-63c0-3a10babb4d71"),
            MedicoId = new Guid("7eccb77e-4f6b-3e06-1663-3a10ddebcf43"),
            Sintomas = new List<string> { "Febre","Vômito", "Diarréia" },
            Diagnostico = "Virose",
            Status = 0
        };
    }
    
}
    
