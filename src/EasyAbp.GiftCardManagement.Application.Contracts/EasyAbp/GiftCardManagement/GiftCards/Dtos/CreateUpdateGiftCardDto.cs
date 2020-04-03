using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class CreateUpdateGiftCardDto
    {
        [DisplayName("GiftCardGiftCardTemplateId")]
        public Guid GiftCardTemplateId { get; set; }

        [DisplayName("GiftCardCode")]
        public string Code { get; set; }
        
        [DisplayName("GiftCardPasswordHash")]
        public string PasswordHash { get; set; }

        [DisplayName("GiftCardExpiration")]
        public DateTime? Expiration { get; set; }

        [DisplayName("GiftCardConsumptionUserId")]
        public Guid? ConsumptionUserId { get; set; }

        [DisplayName("GiftCardConsumptionTime")]
        public DateTime? ConsumptionTime { get; set; }
    }
}