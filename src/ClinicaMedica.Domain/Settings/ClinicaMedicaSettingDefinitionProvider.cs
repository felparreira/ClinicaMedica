using Volo.Abp.Settings;

namespace ClinicaMedica.Settings;

public class ClinicaMedicaSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ClinicaMedicaSettings.MySetting1));
    }
}
