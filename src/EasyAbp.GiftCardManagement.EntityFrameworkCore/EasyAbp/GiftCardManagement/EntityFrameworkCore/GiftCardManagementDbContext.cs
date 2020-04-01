using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.GiftCardManagement.GiftCardTemplates;
using EasyAbp.GiftCardManagement.GiftCards;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore
{
    [ConnectionStringName(GiftCardManagementDbProperties.ConnectionStringName)]
    public class GiftCardManagementDbContext : AbpDbContext<GiftCardManagementDbContext>, IGiftCardManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<GiftCardTemplate> GiftCardTemplates { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }

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
