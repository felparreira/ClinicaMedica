using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ClinicaMedica.Data;

/* This is used if database provider does't define
 * IClinicaMedicaDbSchemaMigrator implementation.
 */
public class NullClinicaMedicaDbSchemaMigrator : IClinicaMedicaDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
