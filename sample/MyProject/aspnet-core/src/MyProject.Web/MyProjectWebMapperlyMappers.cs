using MyProject.Gifts.Dtos;
using MyProject.UserGifts.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace MyProject.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class GiftDtoToCreateUpdateGiftDtoMapper : MapperBase<GiftDto, CreateUpdateGiftDto>
    {
        public override partial CreateUpdateGiftDto Map(GiftDto source);
        public override partial void Map(GiftDto source, CreateUpdateGiftDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class UserGiftDtoToCreateUpdateUserGiftDtoMapper : MapperBase<UserGiftDto, CreateUpdateUserGiftDto>
    {
        public override partial CreateUpdateUserGiftDto Map(UserGiftDto source);
        public override partial void Map(UserGiftDto source, CreateUpdateUserGiftDto destination);
    }
}
