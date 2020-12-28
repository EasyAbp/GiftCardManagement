using System;
using System.Collections.Generic;
using Volo.Abp.Data;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    [Serializable]
    public class GiftCardConsumedEto
    {
        public string GiftCardTemplateName { get; set; }
        
        public ExtraPropertyDictionary GiftCardTemplateExtraProperties { get; set; }
        
        public string GiftCardCode { get; set; }
        
        public ExtraPropertyDictionary GiftCardExtraProperties { get; set; }
        
        public Guid? ConsumptionUserId { get; set; }
    }
}