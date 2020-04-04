using System;
using System.Collections.Generic;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    [Serializable]
    public class GiftCardConsumedEto
    {
        public string GiftCardTemplateName { get; set; }
        
        public Dictionary<string, object> GiftCardTemplateExtraProperties { get; set; }
        
        public string GiftCardCode { get; set; }
        
        public Dictionary<string, object> GiftCardExtraProperties { get; set; }
        
        public Guid? ConsumptionUserId { get; set; }
    }
}