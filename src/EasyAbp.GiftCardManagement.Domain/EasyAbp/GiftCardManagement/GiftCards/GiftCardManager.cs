using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly IGiftCardRepository _repository;
        private readonly IGiftCardPasswordHashProvider _giftCardPasswordHashProvider;

        public GiftCardManager(
            IClock clock,
            IDistributedEventBus distributedEventBus,
            IUnitOfWorkManager unitOfWorkManager,
            IGiftCardRepository repository,
            IGiftCardPasswordHashProvider giftCardPasswordHashProvider)
        {
            _clock = clock;
            _distributedEventBus = distributedEventBus;
            _unitOfWorkManager = unitOfWorkManager;
            _repository = repository;
            _giftCardPasswordHashProvider = giftCardPasswordHashProvider;
        }

        public async Task<GiftCard> GetUsableAsync(string code, string password)
        {
            var giftCard = await _repository.GetAsync(code, _giftCardPasswordHashProvider.GetPasswordHash(password));

            giftCard.CheckUsable(_clock);

            return giftCard;
        }

        public async Task ConsumeAsync(GiftCard giftCard, Guid? userId, Dictionary<string, object> extraProperties = null)
        {
            giftCard.Consume(_clock, userId, extraProperties);

            await _repository.UpdateAsync(giftCard, true);

            _unitOfWorkManager.Current.OnCompleted(async () => await _distributedEventBus.PublishAsync(
                new GiftCardConsumedEto
                {
                    GiftCardId = giftCard.Id,
                    GiftCardCode = giftCard.Code
                }));
        }
    }
}