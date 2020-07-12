using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.Authorization;
using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.GiftCardManagement.Web.Menus
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
            var l = context.GetLocalizer<GiftCardManagementResource>();            //Add main menu items.

            var menuItem = new ApplicationMenuItem(GiftCardManagementMenus.Prefix, l["Menu:GiftCardManagement"]);
            
            if (await context.IsGrantedAsync(GiftCardManagementPermissions.GiftCardTemplates.Default))
            {
                menuItem.AddItem(
                    new ApplicationMenuItem(GiftCardManagementMenus.GiftCardTemplate, l["Menu:GiftCardTemplate"], "/GiftCardManagement/GiftCardTemplates/GiftCardTemplate")
                );
            }
            
            if (await context.IsGrantedAsync(GiftCardManagementPermissions.GiftCards.Consume))
            {
                menuItem.AddItem(
                    new ApplicationMenuItem(GiftCardManagementMenus.GiftCardConsumption, l["Menu:GiftCardConsumption"], "/GiftCardManagement/GiftCards/GiftCard/Consume")
                );
            }

            if (!menuItem.Items.IsNullOrEmpty())
            {
                context.Menu.AddItem(menuItem);
            }
        }
    }
}
