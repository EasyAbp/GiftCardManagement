using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class GiftCardDto : FullAuditedEntityDto<Guid>
    {
        public Guid GiftCardTemplateId { get; set; }

        public string Code { get; set; }

        public string PasswordHash { get; set; }

        public DateTime? Expiration { get; set; }

        public Guid? ConsumptionUserId { get; set; }

        public DateTime? ConsumptionTime { get; set; }
        
        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}