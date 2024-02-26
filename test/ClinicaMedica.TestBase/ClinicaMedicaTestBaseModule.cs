using Autofac;
using ClinicaMedica.MongoDB;
using ClinicaMedica.MongoDB.Tratamentos;
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
    typeof(AbpBackgroundJobsAbstractionsModule)
    )]
public class ClinicaMedicaTestBaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddScoped<ITratamentoRepository, TratamentoRepository>();
        
        context.Services.AddMongoDbContext<ClinicaMedicaMongoDbContext>(options =>
        {
            options.AddDefaultRepositories();
            options.AddRepository<Tratamento, TratamentoRepository>();

        });
        
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });

        context.Services.AddAlwaysAllowAuthorization();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        //SeedTestData(context);
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
