using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MyProject.Gifts
{
    public interface IGiftRepository : IRepository<Gift, Guid>
    {
        Task<Gift> GetAsync(string name, CancellationToken cancellationToken = default);
    }
}