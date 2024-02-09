using Volo.Abp.Modularity;

namespace ClinicaMedica;

public abstract class ClinicaMedicaApplicationTestBase<TStartupModule> : ClinicaMedicaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
