using Volo.Abp.Modularity;

namespace ClinicaMedica;

[DependsOn(
    typeof(ClinicaMedicaApplicationModule),
    typeof(ClinicaMedicaDomainTestModule)
)]
public class ClinicaMedicaApplicationTestModule : AbpModule
{

}
