using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Data;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class ConsumeGiftCardDto : ExtensibleObject
    {
        public string Code { get; set; }
        
        public string Password { get; set; }
    }
}