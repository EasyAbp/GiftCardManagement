using System;
using Volo.Abp;

namespace MyProject.UserGifts
{
    public class GiftCardConsumptionUserIdEmptyException : BusinessException
    {
        public GiftCardConsumptionUserIdEmptyException(Guid giftCardId) : base(
            message: $"ConsumptionUserId property of the gift card ({giftCardId}) is null.")
        {

        }
    }
}