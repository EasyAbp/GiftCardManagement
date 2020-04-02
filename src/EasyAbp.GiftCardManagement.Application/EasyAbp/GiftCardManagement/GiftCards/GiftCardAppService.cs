using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.Authorization;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Uow;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardAppService : CrudAppService<GiftCard, GiftCardDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateGiftCardDto, CreateUpdateGiftCardDto>,
        IGiftCardAppService
    {
        protected override string CreatePolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Create;
        protected override string DeletePolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Delete;
        protected override string UpdatePolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Update;
        protected override string GetPolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Default;
        protected override string GetListPolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Default;

        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ILocalEventBus _localEventBus;
        private readonly IDistributedEventBus _distributedEventBus;
        private readonly IGiftCardManager _giftCardManager;

        public GiftCardAppService(
            IUnitOfWorkManager unitOfWorkManager,
            ILocalEventBus localEventBus,
            IDistributedEventBus distributedEventBus,
            IGiftCardManager giftCardManager,
            IGiftCardRepository repository) : base(repository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _localEventBus = localEventBus;
            _distributedEventBus = distributedEventBus;
            _giftCardManager = giftCardManager;
        }

        public virtual async Task PreConsumeAsync(ConsumeGiftCardDto input)
        {
            await _giftCardManager.GetUsableAsync(input.Code, input.Password);
        }

        [UnitOfWork(IsDisabled = true)]
        public virtual async Task ConsumeAsync(ConsumeGiftCardDto input)
        {
            using var uow = _unitOfWorkManager.Begin(true, true);
            
            var giftCard = await _giftCardManager.GetUsableAsync(input.Code, input.Password);

            await _giftCardManager.ConsumeAsync(giftCard, CurrentUser.Id, input.ExtraInformation);

            await uow.CompleteAsync();

            await PublishEventAsync(giftCard.Code, CurrentUser.Id, input.ExtraInformation);
        }

        protected virtual async Task PublishEventAsync(string giftCardCode, Guid? userId, string extraInformation)
        {
            var eto = new GiftCardConsumedEto
            {
                Code = giftCardCode,
                UserId = userId,
                ExtraInformation = extraInformation
            };
            
            await _localEventBus.PublishAsync(eto);
            
            await _distributedEventBus.PublishAsync(eto);
        }
    }
}