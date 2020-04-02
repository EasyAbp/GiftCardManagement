using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Timing;
using Volo.Abp.Uow;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardManager : DomainService, IGiftCardManager
    {
        private readonly IClock _clock;
        private readonly IGiftCardRepository _repository;
        private readonly IGiftCardPasswordHashProvider _giftCardPasswordHashProvider;

        public GiftCardManager(
            IClock clock,
            IGiftCardRepository repository,
            IGiftCardPasswordHashProvider giftCardPasswordHashProvider)
        {
            _clock = clock;
            _repository = repository;
            _giftCardPasswordHashProvider = giftCardPasswordHashProvider;
        }

        public async Task<GiftCard> GetUsableAsync(string code, string password)
        {
            var giftCard = await _repository.GetAsync(code, _giftCardPasswordHashProvider.GetPasswordHash(password));

            giftCard.CheckUsable(_clock);

            return giftCard;
        }
        
        public async Task ConsumeAsync(GiftCard giftCard, Guid? userId, string extraInformation = null)
        {
            giftCard.Consume(_clock, userId);

            await _repository.UpdateAsync(giftCard, true);
        }
    }
}