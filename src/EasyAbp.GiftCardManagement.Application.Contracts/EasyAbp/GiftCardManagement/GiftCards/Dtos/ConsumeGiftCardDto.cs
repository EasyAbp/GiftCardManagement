using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Data;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class ConsumeGiftCardDto : IHasExtraProperties
    {
        public string Code { get; set; }
        
        public string Password { get; set; }
        
        public ExtraPropertyDictionary ExtraProperties { get; set; }
    }
}