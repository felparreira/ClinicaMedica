using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaMedica.Exceptions;

namespace ClinicaMedica.Tratamentos;

public sealed class TratamentoTest : ClinicaMedicaApplicationTestBase<ClinicaMedicaApplicationTestModule>
{
    private readonly TratamentoAppService _tratamentoAppService;
    
    public TratamentoTest(TratamentoAppService tratamentoAppService)
    {
        _tratamentoAppService = GetRequiredService<TratamentoAppService>();
    }

    public async Task ShouldCreateATreatment()
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
        
    
    
    
}