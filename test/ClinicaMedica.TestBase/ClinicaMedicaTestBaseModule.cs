using Autofac;
using ClinicaMedica.MongoDb;
using ClinicaMedica.MongoDb.Tratamentos;
using ClinicaMedica.Tratamentos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.Threading;

namespace ClinicaMedica;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpTestBaseModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpBackgroundJobsAbstractionsModule),
    typeof(ClinicaMedicaDomainModule)
    )]
public class ClinicaMedicaTestBaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });

        context.Services.AddAlwaysAllowAuthorization();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        SeedTestData(context);
    }

    private static void SeedTestData(ApplicationInitializationContext context)
    {
        AsyncHelper.RunSync(async () =>
        {
            using (var scope = context.ServiceProvider.CreateScope())
            {
                await scope.ServiceProvider
                    .GetRequiredService<IDataSeeder>()
                    .SeedAsync();
            }
        });
    }
    
    public void ConfigureContainer(ContainerBuilder builder)
    {
        // Registrar o serviço TratamentoRepository
        builder.RegisterType<TratamentoRepository>().As<ITratamentoRepository>();
    }
}
