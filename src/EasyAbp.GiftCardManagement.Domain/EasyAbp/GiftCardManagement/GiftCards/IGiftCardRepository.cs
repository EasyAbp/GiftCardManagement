using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public interface IGiftCardRepository : IRepository<GiftCard, Guid>
    {
    }
}