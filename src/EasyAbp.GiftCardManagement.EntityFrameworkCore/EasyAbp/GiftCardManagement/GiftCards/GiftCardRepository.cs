using System;
using EasyAbp.GiftCardManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.GiftCardManagement.GiftCards
{
    public class GiftCardRepository : EfCoreRepository<GiftCardManagementDbContext, GiftCard, Guid>, IGiftCardRepository
    {
        public GiftCardRepository(IDbContextProvider<GiftCardManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}