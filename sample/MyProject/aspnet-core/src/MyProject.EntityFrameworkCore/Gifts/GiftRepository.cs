using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyProject.Gifts
{
    public class GiftRepository : EfCoreRepository<MyProjectDbContext, Gift, Guid>, IGiftRepository
    {
        public GiftRepository(IDbContextProvider<MyProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Gift> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            var gift = await (await GetQueryableAsync()).Where(g => g.Name.Equals(name))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (gift == null)
            {
                throw new EntityNotFoundException(typeof(Gift), name);
            }

            return gift;
        }
    }
}