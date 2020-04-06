using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace EasyAbp.GiftCardManagement
{
    public class GiftCardManagementApplicationAutoMapperProfile : Profile
    {
        public GiftCardManagementApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<GiftCardTemplate, GiftCardTemplateDto>();
            CreateMap<CreateUpdateGiftCardTemplateDto, GiftCardTemplate>(MemberList.Source);
            CreateMap<GiftCard, GiftCardDto>();
            CreateMap<UpdateGiftCardDto, GiftCard>(MemberList.None);
        }
    }
}
