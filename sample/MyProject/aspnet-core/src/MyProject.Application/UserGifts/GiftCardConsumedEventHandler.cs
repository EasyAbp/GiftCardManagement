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
        private readonly IGiftCardTemplateAppService _giftCardTemplateAppService;
        private readonly IGiftCardAppService _giftCardAppService;
        private readonly IUserGiftRepository _userGiftRepository;

        public GiftCardConsumedEventHandler(
            IGuidGenerator guidGenerator,
            IGiftAppService giftAppService,
            IGiftCardTemplateAppService giftCardTemplateAppService,
            IGiftCardAppService giftCardAppService,
            IUserGiftRepository userGiftRepository)
        {
            _guidGenerator = guidGenerator;
            _giftAppService = giftAppService;
            _giftCardTemplateAppService = giftCardTemplateAppService;
            _giftCardAppService = giftCardAppService;
            _userGiftRepository = userGiftRepository;
        }
        
        public async Task HandleEventAsync(GiftCardConsumedEto eventData)
        {
            if (!eventData.GiftCardTemplateName.StartsWith("Gift:"))
            {
                return;
            }
            
            var giftCard = await _giftCardAppService.GetAsync(eventData.GiftCardId);

            var giftCardTemplate = await _giftCardTemplateAppService.GetAsync(giftCard.GiftCardTemplateId);

            var giftName = giftCardTemplate.ExtraProperties.GetOrDefault("GiftName").As<string>();
            
            var gift = await _giftAppService.GetByNameAsync(giftName);

            if (giftName.IsNullOrWhiteSpace())
            {
                throw new GiftCardGiftNameNotDefinedException(giftCardTemplate.Id);
            }

            if (!giftCard.ConsumptionUserId.HasValue)
            {
                throw new GiftCardConsumptionUserIdEmptyException(giftCard.Id);
            }

            await _userGiftRepository.InsertAsync(new UserGift(_guidGenerator.Create(),
                giftCard.ConsumptionUserId.Value, gift.Id));
        }
    }
}