using Volo.Abp.Modularity;

namespace EasyAbp.GiftCardManagement
{
    [DependsOn(
        typeof(GiftCardManagementApplicationModule),
        typeof(GiftCardManagementDomainTestModule)
        )]
    public class GiftCardManagementApplicationTestModule : AbpModule
    {

    }
}
