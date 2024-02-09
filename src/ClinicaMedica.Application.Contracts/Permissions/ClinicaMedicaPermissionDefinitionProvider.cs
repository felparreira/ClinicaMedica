using ClinicaMedica.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ClinicaMedica.Permissions;

public class ClinicaMedicaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ClinicaMedicaPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ClinicaMedicaPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ClinicaMedicaResource>(name);
    }
}
