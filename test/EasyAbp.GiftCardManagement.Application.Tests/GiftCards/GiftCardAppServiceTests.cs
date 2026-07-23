using System;
using EasyAbp.GiftCardManagement.GiftCards.Dtos;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardAppServiceTests : GiftCardManagementApplicationTestBase
    {
        private readonly IGiftCardAppService _giftCardAppService;
        private readonly IObjectMapper<GiftCardManagementApplicationModule> _objectMapper;

        public GiftCardAppServiceTests()
        {
            _giftCardAppService = GetRequiredService<IGiftCardAppService>();
            _objectMapper = GetRequiredService<IObjectMapper<GiftCardManagementApplicationModule>>();
        }

        [Fact]
        public void Should_Map_GiftCard_To_GiftCardDto()
        {
            // Arrange
            var templateId = Guid.NewGuid();
            var expiration = new DateTime(2030, 1, 1);
            var giftCard = new GiftCard(
                Guid.NewGuid(),
                tenantId: null,
                giftCardTemplateId: templateId,
                code: "SAMPLE-CODE",
                passwordHash: "hashed-password",
                expiration: expiration
            );

            // Act
            var dto = _objectMapper.Map<GiftCard, GiftCardDto>(giftCard);

            // Assert
            dto.Id.ShouldBe(giftCard.Id);
            dto.GiftCardTemplateId.ShouldBe(templateId);
            dto.Code.ShouldBe("SAMPLE-CODE");
            dto.Expiration.ShouldBe(expiration);
            dto.ConsumptionUserId.ShouldBeNull();
            dto.ConsumptionTime.ShouldBeNull();
        }
    }
}
