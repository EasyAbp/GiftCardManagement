using Volo.Abp.Modularity;

namespace EasyAbp.GiftCardManagement
{
    [DependsOn(
        typeof(GiftCardManagementDomainSharedModule)
        )]
    public class GiftCardManagementDomainModule : AbpModule
    {

    }
}
