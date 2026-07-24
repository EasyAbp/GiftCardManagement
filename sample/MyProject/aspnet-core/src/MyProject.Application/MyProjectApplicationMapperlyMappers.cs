using MyProject.Gifts;
using MyProject.Gifts.Dtos;
using MyProject.UserGifts;
using MyProject.UserGifts.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace MyProject
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class GiftToGiftDtoMapper : MapperBase<Gift, GiftDto>
    {
        public override partial GiftDto Map(Gift source);
        public override partial void Map(Gift source, GiftDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class UserGiftToUserGiftDtoMapper : MapperBase<UserGift, UserGiftDto>
    {
        public override partial UserGiftDto Map(UserGift source);
        public override partial void Map(UserGift source, UserGiftDto destination);
    }
}
