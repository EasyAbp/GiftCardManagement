using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCards;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore
{
    [ConnectionStringName(GiftCardManagementDbProperties.ConnectionStringName)]
    public interface IGiftCardManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<GiftCardTemplate> GiftCardTemplates { get; set; }
        DbSet<GiftCard> GiftCards { get; set; }
    }
}
