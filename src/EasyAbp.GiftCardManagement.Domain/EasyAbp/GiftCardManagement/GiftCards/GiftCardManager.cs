using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Timing;
using Volo.Abp.Uow;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardManager : DomainService, IGiftCardManager
    {
        private readonly IClock _clock;
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IGiftCardTemplateRepository _giftCardTemplateRepository;
        private readonly IGiftCardRepository _repository;
        private readonly IGiftCardPasswordHashProvider _giftCardPasswordHashProvider;

        public GiftCardManager(
            IClock clock,
            IDistributedEventBus distributedEventBus,
            IUnitOfWorkManager unitOfWorkManager,
            IGiftCardTemplateRepository giftCardTemplateRepository,
            IGiftCardRepository repository,
            IGiftCardPasswordHashProvider giftCardPasswordHashProvider)
        {
            _clock = clock;
            _distributedEventBus = distributedEventBus;
            _unitOfWorkManager = unitOfWorkManager;
            _giftCardTemplateRepository = giftCardTemplateRepository;
            _repository = repository;
            _giftCardPasswordHashProvider = giftCardPasswordHashProvider;
        }

        public virtual async Task<GiftCard> GetUsableAsync(string code, string password)
        {
            var giftCard = await _repository.GetAsync(code, _giftCardPasswordHashProvider.GetPasswordHash(password));

            giftCard.CheckUsable(_clock);

            return giftCard;
        }

        public virtual async Task ConsumeAsync(GiftCard giftCard, Guid? userId,
            ExtraPropertyDictionary extraProperties = null)
        {
            var template = await _giftCardTemplateRepository.GetAsync(giftCard.GiftCardTemplateId);

            giftCard.Consume(_clock, userId, extraProperties);

            await _repository.UpdateAsync(giftCard, true);

            await _distributedEventBus.PublishAsync(
                new GiftCardConsumedEto
                {
                    GiftCardTemplateName = template.Name,
                    GiftCardTemplateExtraProperties = template.ExtraProperties,
                    GiftCardCode = giftCard.Code,
                    GiftCardExtraProperties = giftCard.ExtraProperties,
                    ConsumptionUserId = userId
                });
        }
    }
}