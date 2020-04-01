using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore
{
    [ConnectionStringName(GiftCardManagementDbProperties.ConnectionStringName)]
    public class GiftCardManagementDbContext : AbpDbContext<GiftCardManagementDbContext>, IGiftCardManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public GiftCardManagementDbContext(DbContextOptions<GiftCardManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureGiftCardManagement();
        }
    }
}