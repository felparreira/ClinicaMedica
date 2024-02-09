using System;
using System.Collections.Generic;
using System.Text;
using ClinicaMedica.Localization;
using Volo.Abp.Application.Services;

namespace ClinicaMedica;

/* Inherit your application services from this class.
 */
public abstract class ClinicaMedicaAppService : ApplicationService
{
    protected ClinicaMedicaAppService()
    {
        LocalizationResource = typeof(ClinicaMedicaResource);
    }
}
