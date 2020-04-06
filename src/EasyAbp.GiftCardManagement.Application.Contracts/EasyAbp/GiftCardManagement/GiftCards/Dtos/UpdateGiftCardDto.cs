using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class UpdateGiftCardDto
    {
        [DisplayName("GiftCardGiftCardTemplateId")]
        public Guid GiftCardTemplateId { get; set; }

        [Required]
        [DisplayName("GiftCardCode")]
        public string Code { get; set; }
        
        [DataType(DataType.Password)]
        [DisplayName("GiftCardPassword")]
        public string Password { get; set; }

        [DisplayName("GiftCardExpiration")]
        public DateTime? Expiration { get; set; }
    }
}