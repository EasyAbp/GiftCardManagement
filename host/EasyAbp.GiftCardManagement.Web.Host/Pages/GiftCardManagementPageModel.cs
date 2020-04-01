using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.GiftCardManagement.Pages
{
    public abstract class GiftCardManagementPageModel : AbpPageModel
    {
        protected GiftCardManagementPageModel()
        {
            LocalizationResourceType = typeof(GiftCardManagementResource);
        }
    }
}