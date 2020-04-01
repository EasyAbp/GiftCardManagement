using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore
{
    [ConnectionStringName(GiftCardManagementDbProperties.ConnectionStringName)]
    public interface IGiftCardManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}