using ClinicaMedica.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ClinicaMedica.Permissions;

public sealed class ClinicaMedicaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var pacientesGroup = context.AddGroup(ClinicaMedicaPermissions.GroupName+".Pacientes", L("Permission:Pacientes"));

        var pacientesPermission = pacientesGroup.AddPermission(ClinicaMedicaPermissions.Pacientes.Default, L(ClinicaMedicaPermissions.Pacientes.Default));
        pacientesPermission.AddChild(ClinicaMedicaPermissions.Pacientes.Create, L(ClinicaMedicaPermissions.Pacientes.Create));
        pacientesPermission.AddChild(ClinicaMedicaPermissions.Pacientes.Get, L(ClinicaMedicaPermissions.Pacientes.Get));
        pacientesPermission.AddChild(ClinicaMedicaPermissions.Pacientes.GetAll, L(ClinicaMedicaPermissions.Pacientes.GetAll));
        pacientesPermission.AddChild(ClinicaMedicaPermissions.Pacientes.Update, L(ClinicaMedicaPermissions.Pacientes.Update));
        pacientesPermission.AddChild(ClinicaMedicaPermissions.Pacientes.Delete, L(ClinicaMedicaPermissions.Pacientes.Delete));
        
        var medicosGroup = context.AddGroup(ClinicaMedicaPermissions.GroupName+".Medicos", L("Permission:Medicos"));

        var medicosPermission = medicosGroup.AddPermission(ClinicaMedicaPermissions.Medicos.Default, L(ClinicaMedicaPermissions.Medicos.Default));
        medicosPermission.AddChild(ClinicaMedicaPermissions.Medicos.Create, L(ClinicaMedicaPermissions.Medicos.Create));
        medicosPermission.AddChild(ClinicaMedicaPermissions.Medicos.Get, L(ClinicaMedicaPermissions.Medicos.Get));
        medicosPermission.AddChild(ClinicaMedicaPermissions.Medicos.GetAll, L(ClinicaMedicaPermissions.Medicos.GetAll));
        medicosPermission.AddChild(ClinicaMedicaPermissions.Medicos.Update, L(ClinicaMedicaPermissions.Medicos.Update));
        medicosPermission.AddChild(ClinicaMedicaPermissions.Medicos.Delete, L(ClinicaMedicaPermissions.Medicos.Delete));
        
        var tratamentosGroup = context.AddGroup(ClinicaMedicaPermissions.GroupName+".Tratamentos", L("Permission:Tratamentos"));

        var tratamentosPermission = tratamentosGroup.AddPermission(ClinicaMedicaPermissions.Tratamentos.Default, L(ClinicaMedicaPermissions.Tratamentos.Default));
        tratamentosPermission.AddChild(ClinicaMedicaPermissions.Tratamentos.Create, L(ClinicaMedicaPermissions.Tratamentos.Create));
        tratamentosPermission.AddChild(ClinicaMedicaPermissions.Tratamentos.Get, L(ClinicaMedicaPermissions.Tratamentos.Get));
        tratamentosPermission.AddChild(ClinicaMedicaPermissions.Tratamentos.GetAll, L(ClinicaMedicaPermissions.Tratamentos.GetAll));
        tratamentosPermission.AddChild(ClinicaMedicaPermissions.Tratamentos.Update, L(ClinicaMedicaPermissions.Tratamentos.Update));
        tratamentosPermission.AddChild(ClinicaMedicaPermissions.Tratamentos.Delete, L(ClinicaMedicaPermissions.Tratamentos.Delete));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ClinicaMedicaResource>(name);
    }
}
