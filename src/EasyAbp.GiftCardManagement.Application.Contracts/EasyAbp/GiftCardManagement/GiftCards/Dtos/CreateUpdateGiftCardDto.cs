using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class CreateUpdateGiftCardDto
    {
        [DisplayName("GiftCardGiftCardTemplateId")]
        public Guid GiftCardTemplateId { get; set; }

        [Required]
        [DisplayName("GiftCardCode")]
        public string Code { get; set; }
        
        [Required]
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