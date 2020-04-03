
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MyProject.Pages.Gifts
{
    public class Index_Tests : MyProjectWebTestBase
    {
        [Fact]
        public async Task Index_Page_Test()
        {
            // Arrange

            // Act
            var response = await GetResponseAsStringAsync("/Gift");

            // Assert
            response.ShouldNotBeNull();
        }
    }
}
