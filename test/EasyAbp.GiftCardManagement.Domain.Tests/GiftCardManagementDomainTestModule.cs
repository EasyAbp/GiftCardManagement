using EasyAbp.GiftCardManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.GiftCardManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(GiftCardManagementEntityFrameworkCoreTestModule)
        )]
    public class GiftCardManagementDomainTestModule : AbpModule
    {
        
    }
}
