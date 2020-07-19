using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Authorization;

namespace EasyAbp.GiftCardManagement
{
    [DependsOn(
        typeof(GiftCardManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class GiftCardManagementApplicationContractsModule : AbpModule
    {

    }
}
