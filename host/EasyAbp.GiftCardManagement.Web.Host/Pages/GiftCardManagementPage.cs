using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.GiftCardManagement.Pages
{
    public abstract class GiftCardManagementPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<GiftCardManagementResource> L { get; set; }
    }
}
