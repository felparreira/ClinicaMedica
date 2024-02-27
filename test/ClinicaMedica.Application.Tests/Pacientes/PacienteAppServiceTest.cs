using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Xunit;

namespace ClinicaMedica.Pacientes;

public abstract class PacienteAppServiceTest<TStartupModule> : ClinicaMedicaApplicationTestBase<TStartupModule>
where TStartupModule : IAbpModule
{
    private readonly IPacientesAppService _pacienteAppService;

    public PacienteAppServiceTest()
    {
        _pacienteAppService = GetRequiredService<IPacientesAppService>();
    }

    [Fact]
    public async Task ListarTodosOsPacientes()
    {
        var listaPacientes = await _pacienteAppService.GetAll(new PagedAndSortedResultRequestDto());
        
        listaPacientes.Count.ShouldBeGreaterThan(0);
    }
}