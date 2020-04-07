using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using MyProject.Gifts;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Guids;

namespace MyProject.UserGifts
{
    public class GiftCardConsumedEventHandler : IDistributedEventHandler<GiftCardConsumedEto>, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IGiftRepository _giftRepository;
        private readonly IUserGiftRepository _userGiftRepository;

        public GiftCardConsumedEventHandler(
            IGuidGenerator guidGenerator,
            IGiftRepository giftRepository,
            IUserGiftRepository userGiftRepository)
        {
            _guidGenerator = guidGenerator;
            _giftRepository = giftRepository;
            _userGiftRepository = userGiftRepository;
        }
        
        public async Task HandleEventAsync(GiftCardConsumedEto eventData)
        {
            if (!eventData.GiftCardTemplateName.StartsWith("Gift:"))
            {
                return;
            }
            
            var giftName = eventData.GiftCardTemplateExtraProperties.GetOrDefault("GiftName").As<string>();
            
            if (giftName.IsNullOrWhiteSpace())
            {
                throw new GiftCardGiftNameNotDefinedException(eventData.GiftCardTemplateName);
            }

            if (!eventData.ConsumptionUserId.HasValue)
            {
                throw new GiftCardConsumptionUserIdEmptyException(eventData.GiftCardCode);
            }

            var gift = await _giftRepository.GetAsync(giftName);

            await _userGiftRepository.InsertAsync(new UserGift(_guidGenerator.Create(),
                eventData.ConsumptionUserId.Value, gift.Id));
        }
    }
}