using Volo.Abp.Modularity;

namespace ClinicaMedica;

/* Inherit from this class for your domain layer tests. */
public abstract class ClinicaMedicaDomainTestBase<TStartupModule> : ClinicaMedicaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
