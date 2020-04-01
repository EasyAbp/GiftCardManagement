using System;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public interface IGiftCardAppService :
        ICrudAppService< 
            GiftCardDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateGiftCardDto,
            CreateUpdateGiftCardDto>
    {

    }
}