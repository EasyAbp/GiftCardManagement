using System;
using System.Threading.Tasks;
using MyProject.Gifts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyProject.Gifts
{
    public interface IGiftAppService :
        ICrudAppService< 
            GiftDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateGiftDto,
            CreateUpdateGiftDto>
    {
        Task<GiftDto> GetByNameAsync(string name);
    }
}