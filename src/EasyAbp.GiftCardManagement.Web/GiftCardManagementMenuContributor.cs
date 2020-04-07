using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasyAbp.GiftCardManagement.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasyAbp.GiftCardManagement.Localization;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.GiftCardManagement.Web
{
    public class GiftCardManagementMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<GiftCardManagementResource>>();            //Add main menu items.

            var menuItem = new ApplicationMenuItem("GiftCardManagement", l["Menu:GiftCardManagement"]);
            
            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

            if (await authorizationService.IsGrantedAsync(GiftCardManagementPermissions.GiftCardTemplates.Default))
            {
                menuItem.AddItem(
                    new ApplicationMenuItem("GiftCardTemplate", l["Menu:GiftCardTemplate"], "/GiftCardManagement/GiftCardTemplates/GiftCardTemplate")
                );
            }
            
            if (await authorizationService.IsGrantedAsync(GiftCardManagementPermissions.GiftCards.Consume))
            {
                menuItem.AddItem(
                    new ApplicationMenuItem("GiftCardConsumption", l["Menu:GiftCardConsumption"], "/GiftCardManagement/GiftCards/GiftCard/Consume")
                );
            }

            if (!menuItem.Items.IsNullOrEmpty())
            {
                context.Menu.AddItem(menuItem);
            }
        }
    }
}
