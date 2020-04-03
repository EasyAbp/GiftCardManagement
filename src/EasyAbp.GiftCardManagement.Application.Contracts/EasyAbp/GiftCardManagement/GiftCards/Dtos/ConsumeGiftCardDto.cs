using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class ConsumeGiftCardDto
    {
        public string Code { get; set; }
        
        public string Password { get; set; }
        
        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}