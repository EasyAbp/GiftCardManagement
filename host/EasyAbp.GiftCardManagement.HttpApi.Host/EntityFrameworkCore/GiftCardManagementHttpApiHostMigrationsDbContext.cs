using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.GiftCardManagement.EntityFrameworkCore
{
    public class GiftCardManagementHttpApiHostMigrationsDbContext : AbpDbContext<GiftCardManagementHttpApiHostMigrationsDbContext>
    {
        public GiftCardManagementHttpApiHostMigrationsDbContext(DbContextOptions<GiftCardManagementHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureGiftCardManagement();
        }
    }
}
