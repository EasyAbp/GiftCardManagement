using System;
using System.ComponentModel;
namespace EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos
{
    public class CreateUpdateGiftCardTemplateDto
    {
        [DisplayName("GiftCardTemplateName")]
        public string Name { get; set; }

        [DisplayName("GiftCardTemplateDisplayName")]
        public string DisplayName { get; set; }

        [DisplayName("GiftCardTemplateDescription")]
        public string Description { get; set; }

        [DisplayName("GiftCardTemplateTenantAllowed")]
        public bool TenantAllowed { get; set; }
    }
}