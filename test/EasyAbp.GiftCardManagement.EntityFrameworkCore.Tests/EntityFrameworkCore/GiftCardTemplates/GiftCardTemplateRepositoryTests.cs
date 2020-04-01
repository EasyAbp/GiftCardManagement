using System;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore.GiftCardTemplates
{
    public class GiftCardTemplateRepositoryTests : GiftCardManagementEntityFrameworkCoreTestBase
    {
        private readonly IRepository<GiftCardTemplate, Guid> _giftCardTemplateRepository;

        public GiftCardTemplateRepositoryTests()
        {
            _giftCardTemplateRepository = GetRequiredService<IRepository<GiftCardTemplate, Guid>>();
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
