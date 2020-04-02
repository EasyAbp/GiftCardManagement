using Volo.Abp;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardAlreadyConsumedException : BusinessException
    {
        public GiftCardAlreadyConsumedException(string giftCardCode)
            : base(message: $"The gift card (code: {giftCardCode}) is already used.")
        {
            
        }
    }
}