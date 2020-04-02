using System;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    [Serializable]
    public class GiftCardConsumedEto
    {
        public string Code { get; set; }
        
        public Guid? UserId { get; set; }
        
        public string ExtraInformation { get; set; }
    }
}