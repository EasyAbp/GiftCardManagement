using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCards;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore.GiftCards
{
    public class GiftCardRepositoryTests : GiftCardManagementEntityFrameworkCoreTestBase
    {
        private readonly IRepository<GiftCard, Guid> _giftCardRepository;

        public GiftCardRepositoryTests()
        {
            _giftCardRepository = GetRequiredService<IRepository<GiftCard, Guid>>();
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
