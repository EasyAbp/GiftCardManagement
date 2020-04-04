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
        private readonly IGiftAppService _giftAppService;
        private readonly IUserGiftRepository _userGiftRepository;

        public GiftCardConsumedEventHandler(
            IGuidGenerator guidGenerator,
            IGiftAppService giftAppService,
            IUserGiftRepository userGiftRepository)
        {
            _guidGenerator = guidGenerator;
            _giftAppService = giftAppService;
            _userGiftRepository = userGiftRepository;
        }
        
        public async Task HandleEventAsync(GiftCardConsumedEto eventData)
        {
            if (!eventData.GiftCardTemplateName.StartsWith("Gift:"))
            {
                return;
            }
            
            var giftName = eventData.GiftCardTemplateExtraProperties.GetOrDefault("GiftName").As<string>();
            
            var gift = await _giftAppService.GetByNameAsync(giftName);

            if (giftName.IsNullOrWhiteSpace())
            {
                throw new GiftCardGiftNameNotDefinedException(eventData.GiftCardTemplateName);
            }

            if (!eventData.ConsumptionUserId.HasValue)
            {
                throw new GiftCardConsumptionUserIdEmptyException(eventData.GiftCardCode);
            }

            await _userGiftRepository.InsertAsync(new UserGift(_guidGenerator.Create(),
                eventData.ConsumptionUserId.Value, gift.Id));
        }
    }
}