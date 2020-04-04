using System;
using EasyAbp.GiftCardManagement.Authorization;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public class GiftCardTemplateAppService : CrudAppService<GiftCardTemplate, GiftCardTemplateDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateGiftCardTemplateDto, CreateUpdateGiftCardTemplateDto>,
        IGiftCardTemplateAppService
    {
        protected override string CreatePolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Create;
        protected override string DeletePolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Delete;
        protected override string UpdatePolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Update;
        protected override string GetPolicyName { get; set; } = null;
        protected override string GetListPolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Default;
        
        private readonly IGiftCardTemplateRepository _repository;

        public GiftCardTemplateAppService(IGiftCardTemplateRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}