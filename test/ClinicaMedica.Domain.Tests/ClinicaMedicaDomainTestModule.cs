using Volo.Abp.Modularity;

namespace ClinicaMedica;

[DependsOn(
    typeof(ClinicaMedicaDomainModule),
    typeof(ClinicaMedicaTestBaseModule)
)]
public class ClinicaMedicaDomainTestModule : AbpModule
{

}
