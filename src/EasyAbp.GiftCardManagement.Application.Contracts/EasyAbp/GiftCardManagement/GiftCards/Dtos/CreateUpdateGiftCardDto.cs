using System;
using System.ComponentModel;
namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class CreateUpdateGiftCardDto
    {
        [DisplayName("GiftCardGiftCardTemplateId")]
        public Guid GiftCardTemplateId { get; set; }

        [DisplayName("GiftCardCode")]
        public string Code { get; set; }

        [DisplayName("GiftCardPassword")]
        public string Password { get; set; }

        [DisplayName("GiftCardDueTime")]
        public DateTime DueTime { get; set; }

        [DisplayName("GiftCardConsumptionUserId")]
        public Guid? ConsumptionUserId { get; set; }

        [DisplayName("GiftCardConsumptionTime")]
        public DateTime? ConsumptionTime { get; set; }
    }
}