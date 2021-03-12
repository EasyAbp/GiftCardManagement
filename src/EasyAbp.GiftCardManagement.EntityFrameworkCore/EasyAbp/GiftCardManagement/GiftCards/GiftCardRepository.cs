using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.GiftCardManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardRepository : EfCoreRepository<IGiftCardManagementDbContext, GiftCard, Guid>, IGiftCardRepository
    {
        public GiftCardRepository(IDbContextProvider<IGiftCardManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<GiftCard> FindAsync(string code, string passwordHash,
            CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).Where(c => c.Code == code && c.PasswordHash == passwordHash)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<GiftCard> GetAsync(string code, string passwordHash, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(code, passwordHash, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(GiftCard), code);
            }

            return entity;
        }
    }
}