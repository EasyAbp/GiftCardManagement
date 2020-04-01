using System;
using EasyAbp.GiftCardManagement.Authorization;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

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
        
        private readonly IGiftCardRepository _repository;

        public GiftCardAppService(IGiftCardRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}