using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos
{
    public class GiftCardTemplateDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool TenantAllowed { get; set; }
        
        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}