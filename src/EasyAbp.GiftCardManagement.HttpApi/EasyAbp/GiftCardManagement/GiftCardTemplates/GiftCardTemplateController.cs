using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    [RemoteService(Name = "EasyAbpGiftCardManagement")]
    [Route("/api/giftCardManagement/giftCardTemplate")]
    public class GiftCardTemplateController : GiftCardManagementController, IGiftCardTemplateAppService
    {
        private readonly IGiftCardTemplateAppService _service;

        public GiftCardTemplateController(IGiftCardTemplateAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<GiftCardTemplateDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<GiftCardTemplateDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<GiftCardTemplateDto> CreateAsync(CreateUpdateGiftCardTemplateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<GiftCardTemplateDto> UpdateAsync(Guid id, CreateUpdateGiftCardTemplateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}