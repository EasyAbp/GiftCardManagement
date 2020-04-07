using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.Authorization;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public class GiftCardTemplateAppService : CrudAppService<GiftCardTemplate, GiftCardTemplateDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateGiftCardTemplateDto, CreateUpdateGiftCardTemplateDto>,
        IGiftCardTemplateAppService
    {
        protected override string CreatePolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Create;
        protected override string DeletePolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Delete;
        protected override string UpdatePolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Update;
        protected override string GetPolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Default;
        protected override string GetListPolicyName { get; set; } = GiftCardManagementPermissions.GiftCardTemplates.Default;
        
        private readonly IGiftCardTemplateRepository _repository;

        public GiftCardTemplateAppService(IGiftCardTemplateRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<GiftCardTemplate> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return CurrentTenant.Id.HasValue
                ? base.CreateFilteredQuery(input).Where(t => t.TenantAllowed)
                : base.CreateFilteredQuery(input);
        }

        protected override async Task<GiftCardTemplate> GetEntityByIdAsync(Guid id)
        {
            var template = await base.GetEntityByIdAsync(id);

            if (CurrentTenant.Id.HasValue && !template.TenantAllowed)
            {
                throw new EntityNotFoundException(typeof(GiftCardTemplate), id);
            }

            return template;
        }
    }
}