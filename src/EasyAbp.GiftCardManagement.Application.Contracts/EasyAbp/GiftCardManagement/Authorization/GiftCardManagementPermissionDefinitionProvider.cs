using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.GiftCardManagement.Authorization
{
    public class GiftCardManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(GiftCardManagementPermissions.GroupName, L("Permission:GiftCardManagement"));

            var giftCards = moduleGroup.AddPermission(GiftCardManagementPermissions.GiftCards.Default, L("Permission:GiftCard"));
            giftCards.AddChild(GiftCardManagementPermissions.GiftCards.Consume, L("Permission:Consume"));
            giftCards.AddChild(GiftCardManagementPermissions.GiftCards.Manage, L("Permission:Manage"));
            giftCards.AddChild(GiftCardManagementPermissions.GiftCards.Create, L("Permission:Create"));
            giftCards.AddChild(GiftCardManagementPermissions.GiftCards.Update, L("Permission:Update"));
            giftCards.AddChild(GiftCardManagementPermissions.GiftCards.Delete, L("Permission:Delete"));
            
            var giftCardTemplates = moduleGroup.AddPermission(GiftCardManagementPermissions.GiftCardTemplates.Default, L("Permission:GiftCardTemplate"));
            giftCardTemplates.AddChild(GiftCardManagementPermissions.GiftCardTemplates.Create, L("Permission:Create"), MultiTenancySides.Host);
            giftCardTemplates.AddChild(GiftCardManagementPermissions.GiftCardTemplates.Update, L("Permission:Update"), MultiTenancySides.Host);
            giftCardTemplates.AddChild(GiftCardManagementPermissions.GiftCardTemplates.Delete, L("Permission:Delete"), MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<GiftCardManagementResource>(name);
        }
    }
}