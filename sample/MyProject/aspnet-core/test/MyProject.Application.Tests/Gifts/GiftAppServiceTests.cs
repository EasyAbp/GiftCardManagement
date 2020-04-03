using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Gifts
{
    public class GiftAppServiceTests : MyProjectApplicationTestBase
    {
        private readonly IGiftAppService _giftAppService;

        public GiftAppServiceTests()
        {
            _giftAppService = GetRequiredService<IGiftAppService>();
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
