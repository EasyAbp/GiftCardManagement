using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.GiftCardManagement.MongoDB
{
    [ConnectionStringName(GiftCardManagementDbProperties.ConnectionStringName)]
    public interface IGiftCardManagementMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
