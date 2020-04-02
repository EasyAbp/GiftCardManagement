using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class ConsumeGiftCardDto
    {
        public static readonly int ExtraInformationMaxLength = 200;
        
        public string Code { get; set; }
        
        public string Password { get; set; }
        
        [StringLength(GiftCardConsts.MaxExtraInformationLength)]
        public string ExtraInformation { get; set; }
    }
}