using System;
using System.Threading.Tasks;
using MyProject.UserGifts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace MyProject.EntityFrameworkCore.UserGifts
{
    public class UserGiftRepositoryTests : MyProjectEntityFrameworkCoreTestBase
    {
        private readonly IRepository<UserGift, Guid> _userGiftRepository;

        public UserGiftRepositoryTests()
        {
            _userGiftRepository = GetRequiredService<IRepository<UserGift, Guid>>();
        }

        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
