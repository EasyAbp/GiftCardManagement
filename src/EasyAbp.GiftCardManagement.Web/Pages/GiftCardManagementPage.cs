using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.GiftCardManagement.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagementPage
     */
    public abstract class GiftCardManagementPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<GiftCardManagementResource> L { get; set; }
    }
}
