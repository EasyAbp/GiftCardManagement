using Volo.Abp;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardOverdueException : BusinessException
    {
        public GiftCardOverdueException(string giftCardCode)
            : base(message: $"The gift card (code: {giftCardCode}) is overdue.")
        {
            
        }
    }
}