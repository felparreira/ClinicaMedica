using ClinicaMedica.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ClinicaMedica.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ClinicaMedicaController : AbpControllerBase
{
    protected ClinicaMedicaController()
    {
        LocalizationResource = typeof(ClinicaMedicaResource);
    }
}
