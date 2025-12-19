using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.Authorization;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.Localization;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Uow;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardAppService : CrudAppService<GiftCard, GiftCardDto, Guid, GetGiftCardListDto, CreateGiftCardDto, UpdateGiftCardDto>,
        IGiftCardAppService
    {
        protected override string CreatePolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Create;
        protected override string DeletePolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Delete;
        protected override string UpdatePolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Update;
        protected override string GetPolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Manage;
        protected override string GetListPolicyName { get; set; } = GiftCardManagementPermissions.GiftCards.Manage;

        private readonly IGiftCardPasswordHashProvider _giftCardPasswordHashProvider;
        private readonly IGiftCardManager _giftCardManager;
        private readonly IGiftCardTemplateRepository _giftCardTemplateRepository;

        public GiftCardAppService(
            IGiftCardPasswordHashProvider giftCardPasswordHashProvider,
            IGiftCardManager giftCardManager,
            IGiftCardTemplateRepository giftCardTemplateRepository,
            IGiftCardRepository repository) : base(repository)
        {
            _giftCardPasswordHashProvider = giftCardPasswordHashProvider;
            _giftCardManager = giftCardManager;
            _giftCardTemplateRepository = giftCardTemplateRepository;

            LocalizationResource = typeof(GiftCardManagementResource);
            ObjectMapperContext = typeof(GiftCardManagementApplicationModule);
        }

        protected override async Task<IQueryable<GiftCard>> CreateFilteredQueryAsync(GetGiftCardListDto input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .Where(giftCard => giftCard.GiftCardTemplateId == input.GiftCardTemplateId);
        }

        public virtual async Task ConsumeAsync(ConsumeGiftCardDto input)
        {
            var giftCard = await _giftCardManager.GetUsableAsync(input.Code, input.Password);

            var template = await _giftCardTemplateRepository.GetAsync(giftCard.GiftCardTemplateId);

            if (CurrentTenant.Id.HasValue && !template.TenantAllowed)
            {
                throw new GiftCardTemplateTenantNotAllowedException(template.Id);
            }
            
            if (!template.AnonymousConsumptionAllowed)
            {
                await AuthorizationService.CheckAsync(GiftCardManagementPermissions.GiftCards.Consume);
            }

            await _giftCardManager.ConsumeAsync(giftCard, CurrentUser.Id, input.ExtraProperties);
        }

        protected override GiftCard MapToEntity(CreateGiftCardDto createInput)
        {
            return new GiftCard(
                GuidGenerator.Create(),
                CurrentTenant.Id,
                createInput.GiftCardTemplateId,
                createInput.Code,
                _giftCardPasswordHashProvider.GetPasswordHash(createInput.Password),
                createInput.Expiration
            );
        }

        protected override void MapToEntity(UpdateGiftCardDto input, GiftCard entity)
        {
            base.MapToEntity(input, entity);

            if (!input.Password.IsNullOrWhiteSpace())
            {
                entity.ChangePasswordHash(_giftCardPasswordHashProvider.GetPasswordHash(input.Password));
            }
        }

        public virtual async Task<IEnumerable<GiftCardDto>> CreateBatchAsync(IEnumerable<CreateGiftCardDto> input)
        {
            await CheckCreatePolicyAsync();

            var dtos = new List<GiftCardDto>();
            
            foreach (var item in input)
            {
                var giftCard = MapToEntity(item);
                
                await Repository.InsertAsync(giftCard);

                dtos.Add(MapToGetOutputDto(giftCard));
            }

            return dtos;
        }
    }
}