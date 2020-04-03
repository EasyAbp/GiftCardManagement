using MyProject.Gifts.Dtos;
using MyProject.UserGifts.Dtos;
using AutoMapper;

namespace MyProject.Web
{
    public class MyProjectWebAutoMapperProfile : Profile
    {
        public MyProjectWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<GiftDto, CreateUpdateGiftDto>();
            CreateMap<UserGiftDto, CreateUpdateUserGiftDto>();
        }
    }
}
