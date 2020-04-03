using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.UserGifts
{
    public class UserGiftAppServiceTests : MyProjectApplicationTestBase
    {
        private readonly IUserGiftAppService _userGiftAppService;

        public UserGiftAppServiceTests()
        {
            _userGiftAppService = GetRequiredService<IUserGiftAppService>();
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
