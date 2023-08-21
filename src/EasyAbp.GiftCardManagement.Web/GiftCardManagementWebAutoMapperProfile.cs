using System.Collections.Generic;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using AutoMapper;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCardTemplates.GiftCardTemplate.ViewModels;
using Newtonsoft.Json;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;

namespace EasyAbp.GiftCardManagement.Web
{
    public class GiftCardManagementWebAutoMapperProfile : Profile
    {
        public GiftCardManagementWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<GiftCardTemplateDto, CreateUpdateGiftCardTemplateViewModel>().ForMember(
                model => model.ExtraProperties,
                opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.ExtraProperties)));
            CreateMap<CreateUpdateGiftCardTemplateViewModel, CreateUpdateGiftCardTemplateDto>()
                .ForMember(dto => dto.ExtraProperties,
                    opt => opt.MapFrom(src =>
                        JsonConvert.DeserializeObject<ExtraPropertyDictionary>(src.ExtraProperties)));
            CreateMap<GiftCardDto, CreateGiftCardViewModel>().Ignore(model => model.Password);
            CreateMap<GiftCardDto, UpdateGiftCardDto>().Ignore(dto => dto.Password);
            CreateMap<CreateGiftCardViewModel, CreateGiftCardDto>(MemberList.Source);
            CreateMap<ConsumeGiftCardViewModel, ConsumeGiftCardDto>(MemberList.Source);
        }
    }
}
