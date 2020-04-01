using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.GiftCardManagement
{
    [Dependency(ReplaceServices = true)]
    public class GiftCardManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "GiftCardManagement";
    }
}
