using System;
using Volo.Abp;

namespace MyProject.UserGifts
{
    public class GiftCardConsumptionUserIdEmptyException : BusinessException
    {
        public GiftCardConsumptionUserIdEmptyException(string giftCardCode) : base(
            message: $"ConsumptionUserId property of the gift card ({giftCardCode}) is null.")
        {

        }
    }
}