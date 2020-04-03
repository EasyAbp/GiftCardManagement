using System;
using System.Threading.Tasks;
using MyProject.Gifts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace MyProject.EntityFrameworkCore.Gifts
{
    public class GiftRepositoryTests : MyProjectEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Gift, Guid> _giftRepository;

        public GiftRepositoryTests()
        {
            _giftRepository = GetRequiredService<IRepository<Gift, Guid>>();
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
