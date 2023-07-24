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
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
            });
        }
    }
}