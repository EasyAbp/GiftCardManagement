using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using MyProject.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MyProject.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits MyProject.Web.Pages.MyProjectPage
     */
    public abstract class MyProjectPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<MyProjectResource> L { get; set; }
    }
}
