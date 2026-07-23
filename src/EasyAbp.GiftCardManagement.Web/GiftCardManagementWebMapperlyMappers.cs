using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCards.GiftCard.ViewModels;
using EasyAbp.GiftCardManagement.Web.Pages.GiftCardManagement.GiftCardTemplates.GiftCardTemplate.ViewModels;
using Newtonsoft.Json;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.Mapperly;

namespace EasyAbp.GiftCardManagement.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class GiftCardTemplateDtoToCreateUpdateGiftCardTemplateViewModelMapper
        : MapperBase<GiftCardTemplateDto, CreateUpdateGiftCardTemplateViewModel>
    {
        [MapperIgnoreTarget(nameof(CreateUpdateGiftCardTemplateViewModel.ExtraProperties))]
        public override partial CreateUpdateGiftCardTemplateViewModel Map(GiftCardTemplateDto source);

        [MapperIgnoreTarget(nameof(CreateUpdateGiftCardTemplateViewModel.ExtraProperties))]
        public override partial void Map(GiftCardTemplateDto source, CreateUpdateGiftCardTemplateViewModel destination);

        public override void AfterMap(GiftCardTemplateDto source, CreateUpdateGiftCardTemplateViewModel destination)
        {
            destination.ExtraProperties = JsonConvert.SerializeObject(source.ExtraProperties);
        }
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateUpdateGiftCardTemplateViewModelToCreateUpdateGiftCardTemplateDtoMapper
        : MapperBase<CreateUpdateGiftCardTemplateViewModel, CreateUpdateGiftCardTemplateDto>
    {
        [MapperIgnoreTarget(nameof(CreateUpdateGiftCardTemplateDto.ExtraProperties))]
        public override partial CreateUpdateGiftCardTemplateDto Map(CreateUpdateGiftCardTemplateViewModel source);

        [MapperIgnoreTarget(nameof(CreateUpdateGiftCardTemplateDto.ExtraProperties))]
        public override partial void Map(CreateUpdateGiftCardTemplateViewModel source, CreateUpdateGiftCardTemplateDto destination);

        public override void AfterMap(CreateUpdateGiftCardTemplateViewModel source, CreateUpdateGiftCardTemplateDto destination)
        {
            destination.ExtraProperties.Clear();

            var extraProperties = JsonConvert.DeserializeObject<ExtraPropertyDictionary>(source.ExtraProperties);

            if (extraProperties == null)
            {
                return;
            }

            foreach (var extraProperty in extraProperties)
            {
                destination.ExtraProperties[extraProperty.Key] = extraProperty.Value;
            }
        }
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class GiftCardDtoToCreateGiftCardViewModelMapper : MapperBase<GiftCardDto, CreateGiftCardViewModel>
    {
        [MapperIgnoreTarget(nameof(CreateGiftCardViewModel.Password))]
        public override partial CreateGiftCardViewModel Map(GiftCardDto source);

        [MapperIgnoreTarget(nameof(CreateGiftCardViewModel.Password))]
        public override partial void Map(GiftCardDto source, CreateGiftCardViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class GiftCardDtoToUpdateGiftCardDtoMapper : MapperBase<GiftCardDto, UpdateGiftCardDto>
    {
        [MapperIgnoreTarget(nameof(UpdateGiftCardDto.Password))]
        public override partial UpdateGiftCardDto Map(GiftCardDto source);

        [MapperIgnoreTarget(nameof(UpdateGiftCardDto.Password))]
        public override partial void Map(GiftCardDto source, UpdateGiftCardDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateGiftCardViewModelToCreateGiftCardDtoMapper : MapperBase<CreateGiftCardViewModel, CreateGiftCardDto>
    {
        public override partial CreateGiftCardDto Map(CreateGiftCardViewModel source);
        public override partial void Map(CreateGiftCardViewModel source, CreateGiftCardDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class ConsumeGiftCardViewModelToConsumeGiftCardDtoMapper : MapperBase<ConsumeGiftCardViewModel, ConsumeGiftCardDto>
    {
        [MapperIgnoreTarget(nameof(ConsumeGiftCardDto.ExtraProperties))]
        public override partial ConsumeGiftCardDto Map(ConsumeGiftCardViewModel source);

        [MapperIgnoreTarget(nameof(ConsumeGiftCardDto.ExtraProperties))]
        public override partial void Map(ConsumeGiftCardViewModel source, ConsumeGiftCardDto destination);
    }
}
