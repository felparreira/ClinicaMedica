using ClinicaMedica.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ClinicaMedica.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ClinicaMedicaMongoDbModule),
    typeof(ClinicaMedicaApplicationContractsModule)
    )]
public class ClinicaMedicaDbMigratorModule : AbpModule
{
}
