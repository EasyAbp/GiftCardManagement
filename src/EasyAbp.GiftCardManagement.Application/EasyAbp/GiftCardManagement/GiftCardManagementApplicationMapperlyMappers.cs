using EasyAbp.GiftCardManagement.GiftCards;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.GiftCardManagement
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    [MapExtraProperties]
    public partial class GiftCardTemplateToGiftCardTemplateDtoMapper : MapperBase<GiftCardTemplate, GiftCardTemplateDto>
    {
        [MapperIgnoreTarget(nameof(GiftCardTemplateDto.ExtraProperties))]
        public override partial GiftCardTemplateDto Map(GiftCardTemplate source);

        [MapperIgnoreTarget(nameof(GiftCardTemplateDto.ExtraProperties))]
        public override partial void Map(GiftCardTemplate source, GiftCardTemplateDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    [MapExtraProperties]
    public partial class GiftCardToGiftCardDtoMapper : MapperBase<GiftCard, GiftCardDto>
    {
        [MapperIgnoreTarget(nameof(GiftCardDto.ExtraProperties))]
        public override partial GiftCardDto Map(GiftCard source);

        [MapperIgnoreTarget(nameof(GiftCardDto.ExtraProperties))]
        public override partial void Map(GiftCard source, GiftCardDto destination);
    }
}
