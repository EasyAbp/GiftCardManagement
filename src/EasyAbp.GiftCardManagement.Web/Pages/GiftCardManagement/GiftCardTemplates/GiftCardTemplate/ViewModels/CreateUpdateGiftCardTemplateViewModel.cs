using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCardTemplates.GiftCardTemplate.ViewModels
{
    public class CreateUpdateGiftCardTemplateViewModel
    {
        [Required]
        [DisplayName("GiftCardTemplateName")]
        public string Name { get; set; }

        [Required]
        [DisplayName("GiftCardTemplateDisplayName")]
        public string DisplayName { get; set; }

        [DisplayName("GiftCardTemplateDescription")]
        public string Description { get; set; }

        [TextArea(Rows = 4)]
        [DisplayName("GiftCardTemplateExtraProperties")]
        public string ExtraProperties { get; set; }
        
        [DisplayName("GiftCardTemplateTenantAllowed")]
        public bool TenantAllowed { get; set; }
    
        [DisplayName("GiftCardTemplateAnonymousConsumptionAllowed")]
        public bool AnonymousConsumptionAllowed { get; set; }
    }
}