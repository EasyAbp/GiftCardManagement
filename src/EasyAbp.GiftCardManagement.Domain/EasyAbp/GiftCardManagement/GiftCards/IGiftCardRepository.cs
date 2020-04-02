using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public interface IGiftCardRepository : IRepository<GiftCard, Guid>
    {
        Task<GiftCard> FindAsync(string code, string passwordHash, CancellationToken cancellationToken = default);
        
        Task<GiftCard> GetAsync(string code, string passwordHash, CancellationToken cancellationToken = default);
    }
}