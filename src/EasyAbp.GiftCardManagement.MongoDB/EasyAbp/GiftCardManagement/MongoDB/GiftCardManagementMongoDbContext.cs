using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.GiftCardManagement.MongoDB
{
    [ConnectionStringName(GiftCardManagementDbProperties.ConnectionStringName)]
    public class GiftCardManagementMongoDbContext : AbpMongoDbContext, IGiftCardManagementMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureGiftCardManagement();
        }
    }
}