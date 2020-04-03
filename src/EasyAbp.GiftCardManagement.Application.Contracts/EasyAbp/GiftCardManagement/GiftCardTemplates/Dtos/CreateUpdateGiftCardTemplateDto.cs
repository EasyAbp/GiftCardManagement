using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos
{
    public class CreateUpdateGiftCardTemplateDto
    {
        [Required]
        [DisplayName("GiftCardTemplateName")]
        public string Name { get; set; }

        [Required]
        [DisplayName("GiftCardTemplateDisplayName")]
        public string DisplayName { get; set; }

        [DisplayName("GiftCardTemplateDescription")]
        public string Description { get; set; }


        [DisplayName("GiftCardTemplateTenantAllowed")]
        public bool TenantAllowed { get; set; }
    
        [DisplayName("GiftCardTemplateAnonymousConsumptionAllowed")]
        public bool AnonymousConsumptionAllowed { get; set; }
        
        [DisplayName("GiftCardTemplateExtraProperties")]
        public Dictionary<string, object> ExtraProperties { get; set; }

    }
}