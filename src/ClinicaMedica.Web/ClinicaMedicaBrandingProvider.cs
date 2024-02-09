using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ClinicaMedica.Web;

[Dependency(ReplaceServices = true)]
public class ClinicaMedicaBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ClinicaMedica";
}
