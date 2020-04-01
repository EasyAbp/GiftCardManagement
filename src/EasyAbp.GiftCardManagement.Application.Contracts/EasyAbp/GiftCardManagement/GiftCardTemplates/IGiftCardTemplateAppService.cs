using System;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public interface IGiftCardTemplateAppService :
        ICrudAppService< 
            GiftCardTemplateDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateGiftCardTemplateDto,
            CreateUpdateGiftCardTemplateDto>
    {

    }
}