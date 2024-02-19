using ClinicaMedica.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ClinicaMedica.Permissions;

public sealed class ClinicaMedicaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup("Admin");
        //Define your own permissions here. Example:
        myGroup.AddPermission("Pacientes:Pacientes.Create", isEnabled: true);
        myGroup.AddPermission("Permission:MyPermission2", isEnabled: true);
        myGroup.AddPermission("Permission:MyPermission3", isEnabled: true);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ClinicaMedicaResource>(name);
    }
}
