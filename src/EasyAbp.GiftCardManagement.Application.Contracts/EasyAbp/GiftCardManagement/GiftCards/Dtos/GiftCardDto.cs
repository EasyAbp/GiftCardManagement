using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class GiftCardDto : FullAuditedEntityDto<Guid>
    {
        public Guid GiftCardTemplateId { get; set; }

        public string Code { get; set; }

        public string Password { get; set; }

        public DateTime DueTime { get; set; }

        public Guid? ConsumptionUserId { get; set; }

        public DateTime? ConsumptionTime { get; set; }
    }
}