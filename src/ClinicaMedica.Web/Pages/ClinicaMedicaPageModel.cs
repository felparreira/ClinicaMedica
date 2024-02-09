using ClinicaMedica.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ClinicaMedica.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ClinicaMedicaPageModel : AbpPageModel
{
    protected ClinicaMedicaPageModel()
    {
        LocalizationResourceType = typeof(ClinicaMedicaResource);
    }
}
