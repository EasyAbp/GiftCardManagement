using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public interface IGiftCardAppService :
        ICrudAppService< 
            GiftCardDto, 
            Guid, 
            GetGiftCardListDto,
            CreateGiftCardDto,
            UpdateGiftCardDto>
    {
        Task ConsumeAsync(ConsumeGiftCardDto input);

        Task<IEnumerable<GiftCardDto>> CreateBatchAsync(IEnumerable<CreateGiftCardDto> input);
    }
}