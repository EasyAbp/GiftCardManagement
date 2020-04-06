using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using AutoMapper;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels;
using Volo.Abp.AutoMapper;

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
            CreateMap<GiftCardDto, CreateGiftCardViewModel>().Ignore(model => model.Password);
            CreateMap<GiftCardDto, UpdateGiftCardDto>().Ignore(dto => dto.Password);
            CreateMap<CreateGiftCardViewModel, CreateGiftCardDto>();
        }
    }
}
