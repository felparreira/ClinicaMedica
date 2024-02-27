using ClinicaMedica;
using Microsoft.AspNetCore.Builder;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<ClinicaMedicaWebTestModule>();

namespace ClinicaMedica
{
    public partial class Program
    {
    }
}
