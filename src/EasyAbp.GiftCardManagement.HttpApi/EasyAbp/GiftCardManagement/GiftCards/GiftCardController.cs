using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    [RemoteService(Name = "EasyAbpGiftCardManagement")]
    [Route("/api/giftCardManagement/giftCard")]
    public class GiftCardController : GiftCardManagementController, IGiftCardAppService
    {
        private readonly IGiftCardAppService _service;

        public GiftCardController(IGiftCardAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<GiftCardDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<GiftCardDto>> GetListAsync(GetGiftCardListDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<GiftCardDto> CreateAsync(CreateGiftCardDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<GiftCardDto> UpdateAsync(Guid id, UpdateGiftCardDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpPost]
        [Route("consume")]
        public Task ConsumeAsync(ConsumeGiftCardDto input)
        {
            return _service.ConsumeAsync(input);
        }

        [HttpPost]
        [Route("batch")]
        public Task<IEnumerable<GiftCardDto>> CreateBatchAsync(IEnumerable<CreateGiftCardDto> input)
        {
            return _service.CreateBatchAsync(input);
        }
    }
}