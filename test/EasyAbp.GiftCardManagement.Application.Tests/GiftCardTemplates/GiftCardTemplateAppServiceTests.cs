using System;
using EasyAbp.GiftCardManagement.GiftCardTemplates.Dtos;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public class GiftCardTemplateAppServiceTests : GiftCardManagementApplicationTestBase
    {
        private readonly IGiftCardTemplateAppService _giftCardTemplateAppService;
        private readonly IObjectMapper<GiftCardManagementApplicationModule> _objectMapper;

        public GiftCardTemplateAppServiceTests()
        {
            _giftCardTemplateAppService = GetRequiredService<IGiftCardTemplateAppService>();
            _objectMapper = GetRequiredService<IObjectMapper<GiftCardManagementApplicationModule>>();
        }

        [Fact]
        public void Should_Map_GiftCardTemplate_To_GiftCardTemplateDto()
        {
            // Arrange
            var template = new GiftCardTemplate(
                Guid.NewGuid(),
                "SampleName",
                "Sample Display Name",
                "Sample Description",
                tenantAllowed: true,
                anonymousConsumptionAllowed: false
            );

            // Act
            var dto = _objectMapper.Map<GiftCardTemplate, GiftCardTemplateDto>(template);

            // Assert
            dto.Id.ShouldBe(template.Id);
            dto.Name.ShouldBe("SampleName");
            dto.DisplayName.ShouldBe("Sample Display Name");
            dto.Description.ShouldBe("Sample Description");
            dto.TenantAllowed.ShouldBeTrue();
            dto.AnonymousConsumptionAllowed.ShouldBeFalse();
        }
    }
}
