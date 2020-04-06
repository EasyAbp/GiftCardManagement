using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.GiftCardManagement.GiftCards.Dtos
{
    public class GetGiftCardListDto : PagedAndSortedResultRequestDto
    {
        public Guid GiftCardTemplateId { get; set; }
    }
}