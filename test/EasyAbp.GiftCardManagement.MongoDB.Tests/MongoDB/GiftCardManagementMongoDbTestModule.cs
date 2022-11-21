using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.GiftCardManagement.MongoDB
{
    [DependsOn(
        typeof(GiftCardManagementTestBaseModule),
        typeof(GiftCardManagementMongoDbModule)
        )]
    public class GiftCardManagementMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var stringArray = MongoDbFixture.ConnectionString.Split('?');
            var connectionString = stringArray[0].EnsureEndsWith('/')  +
                                   "Db_" +
                                   Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}