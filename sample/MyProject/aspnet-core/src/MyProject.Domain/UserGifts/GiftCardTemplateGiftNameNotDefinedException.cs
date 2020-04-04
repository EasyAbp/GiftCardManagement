using System;
using Volo.Abp;

namespace MyProject.UserGifts
{
    public class GiftCardGiftNameNotDefinedException : BusinessException
    {
        public GiftCardGiftNameNotDefinedException(string giftCardTemplateName) : base(
            message: $"The gift card ({giftCardTemplateName}) template has no defined gift name property.")
        {

        }
    }
}