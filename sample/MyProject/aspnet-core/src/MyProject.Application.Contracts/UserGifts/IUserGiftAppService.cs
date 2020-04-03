using System;
using MyProject.UserGifts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyProject.UserGifts
{
    public interface IUserGiftAppService :
        ICrudAppService< 
            UserGiftDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateUserGiftDto,
            CreateUpdateUserGiftDto>
    {

    }
}