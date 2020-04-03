using MyProject.Gifts;
using MyProject.Gifts.Dtos;
using MyProject.UserGifts;
using MyProject.UserGifts.Dtos;
using AutoMapper;

namespace MyProject
{
    public class MyProjectApplicationAutoMapperProfile : Profile
    {
        public MyProjectApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Gift, GiftDto>();
            CreateMap<CreateUpdateGiftDto, Gift>(MemberList.Source);
            CreateMap<UserGift, UserGiftDto>();
            CreateMap<CreateUpdateUserGiftDto, UserGift>(MemberList.Source);
        }
    }
}
