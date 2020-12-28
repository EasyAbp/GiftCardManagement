using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Data;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos
{
    public class CreateUpdateGiftCardTemplateDto : IHasExtraProperties
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
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}