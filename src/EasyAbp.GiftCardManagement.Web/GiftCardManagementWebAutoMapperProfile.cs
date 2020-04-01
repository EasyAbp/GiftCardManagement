using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using AutoMapper;

namespace EasyAbp.GiftCardManagement.Web
{
    public class GiftCardManagementWebAutoMapperProfile : Profile
    {
        public GiftCardManagementWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<GiftCardTemplateDto, CreateUpdateGiftCardTemplateDto>();
            CreateMap<GiftCardDto, CreateUpdateGiftCardDto>();
        }
    }
}
