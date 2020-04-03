using System;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    [Serializable]
    public class GiftCardConsumedEto
    {
        public string GiftCardTemplateName { get; set; }
        
        public Guid GiftCardId { get; set; }
        
        public string GiftCardCode { get; set; }
    }
}