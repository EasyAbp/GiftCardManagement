using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.GiftCardManagement.Authorization
{
    public class GiftCardManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(GiftCardManagementPermissions.GroupName, L("Permission:GiftCardManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<GiftCardManagementResource>(name);
        }
    }
}