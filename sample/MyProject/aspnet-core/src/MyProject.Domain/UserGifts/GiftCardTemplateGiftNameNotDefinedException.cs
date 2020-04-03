using System;
using Volo.Abp;

namespace MyProject.UserGifts
{
    public class GiftCardGiftNameNotDefinedException : BusinessException
    {
        public GiftCardGiftNameNotDefinedException(Guid giftCardTemplateId) : base(
            message: $"The gift card ({giftCardTemplateId}) template has no defined gift name property.")
        {

        }
    }
}