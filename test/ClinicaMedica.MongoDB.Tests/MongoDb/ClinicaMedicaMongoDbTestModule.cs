using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace ClinicaMedica.MongoDb;

[DependsOn(
    typeof(ClinicaMedicaApplicationTestModule),
    typeof(ClinicaMedicaMongoDbModule)
    
)]
public class ClinicaMedicaMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = ClinicaMedicaMongoDbFixture.GetRandomConnectionString();
        });
    }
}
