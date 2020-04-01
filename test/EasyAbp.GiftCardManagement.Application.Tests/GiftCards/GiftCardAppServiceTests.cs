using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardAppServiceTests : GiftCardManagementApplicationTestBase
    {
        private readonly IGiftCardAppService _giftCardAppService;

        public GiftCardAppServiceTests()
        {
            _giftCardAppService = GetRequiredService<IGiftCardAppService>();
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
