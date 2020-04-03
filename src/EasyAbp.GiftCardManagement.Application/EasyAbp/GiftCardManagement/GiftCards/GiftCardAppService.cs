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

        private readonly IGiftCardManager _giftCardManager;

        public GiftCardAppService(
            IGiftCardManager giftCardManager,
            IGiftCardRepository repository) : base(repository)
        {
            _giftCardManager = giftCardManager;
        }

        public virtual async Task ConsumeAsync(ConsumeGiftCardDto input)
        {
            var giftCard = await _giftCardManager.GetUsableAsync(input.Code, input.Password);

            await _giftCardManager.ConsumeAsync(giftCard, CurrentUser.Id, input.ExtraProperties);

        }
    }
}