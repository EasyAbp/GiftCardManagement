using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.GiftCardManagement.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class GiftCardManagementPageModel : AbpPageModel
    {
        protected GiftCardManagementPageModel()
        {
            LocalizationResourceType = typeof(GiftCardManagementResource);
            ObjectMapperContext = typeof(GiftCardManagementWebModule);
        }
    }
}