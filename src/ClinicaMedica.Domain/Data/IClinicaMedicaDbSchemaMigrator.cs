using System.Threading.Tasks;

namespace ClinicaMedica.Data;

public interface IClinicaMedicaDbSchemaMigrator
{
    Task MigrateAsync();
}
