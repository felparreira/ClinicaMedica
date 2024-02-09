using Microsoft.AspNetCore.Builder;
using ClinicaMedica;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<ClinicaMedicaWebTestModule>();

public partial class Program
{
}
