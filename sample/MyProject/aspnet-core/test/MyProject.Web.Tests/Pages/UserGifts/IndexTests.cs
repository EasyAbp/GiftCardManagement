
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MyProject.Pages.UserGifts
{
    public class Index_Tests : MyProjectWebTestBase
    {
        [Fact]
        public async Task Index_Page_Test()
        {
            // Arrange

            // Act
            var response = await GetResponseAsStringAsync("/UserGift");

            // Assert
            response.ShouldNotBeNull();
        }
    }
}
