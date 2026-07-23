using System;
using MyProject.UserGifts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyProject.UserGifts
{
    public class UserGiftAppService : CrudAppService<UserGift, UserGiftDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserGiftDto, CreateUpdateUserGiftDto>,
        IUserGiftAppService
    {
        private readonly IUserGiftRepository _repository;

        public UserGiftAppService(IUserGiftRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override UserGift MapToEntity(CreateUpdateUserGiftDto createInput)
        {
            return new UserGift(GuidGenerator.Create(), createInput.UserId, createInput.GiftId);
        }

        protected override void MapToEntity(CreateUpdateUserGiftDto input, UserGift entity)
        {
            entity.Update(input.UserId, input.GiftId);
        }
    }
}