using System;
using EasyAbp.GiftCardManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.GiftCardManagement.GiftCardTemplates
{
    public class GiftCardTemplateRepository : EfCoreRepository<GiftCardManagementDbContext, GiftCardTemplate, Guid>, IGiftCardTemplateRepository
    {
        public GiftCardTemplateRepository(IDbContextProvider<GiftCardManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}