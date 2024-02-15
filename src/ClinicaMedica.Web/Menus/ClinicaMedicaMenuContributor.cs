using System.Threading.Tasks;
using ClinicaMedica.Localization;
using ClinicaMedica.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace ClinicaMedica.Web.Menus;

public class ClinicaMedicaMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<ClinicaMedicaResource>();
        
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Início",
                l["Menu:Home"],
                icon: "fa fa-home",
                url: "/"
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Pacientes",
                l["Menu:Pacientes"],
                icon: "fa fa-user",
                url: "/Pacientes"
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Médicos",
                l["Menu:Medicos"],
                icon: "fa fa-user-nurse",
                url: "/Medicos"
            )
        );
        context.Menu.AddItem(
            new ApplicationMenuItem(
                "Tratamentos",
                l["Menu:Tratamentos"],
                icon: "fa fa-flask",
                url: "/Tratamentos"
            )
        );


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
