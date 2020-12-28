using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class GiftCardDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public Guid GiftCardTemplateId { get; set; }

        public string Code { get; set; }

        public DateTime? Expiration { get; set; }

        public Guid? ConsumptionUserId { get; set; }

        public DateTime? ConsumptionTime { get; set; }
    }
}