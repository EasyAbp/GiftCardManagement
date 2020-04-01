using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public class GiftCardTemplateAppServiceTests : GiftCardManagementApplicationTestBase
    {
        private readonly IGiftCardTemplateAppService _giftCardTemplateAppService;

        public GiftCardTemplateAppServiceTests()
        {
            _giftCardTemplateAppService = GetRequiredService<IGiftCardTemplateAppService>();
        }

        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
