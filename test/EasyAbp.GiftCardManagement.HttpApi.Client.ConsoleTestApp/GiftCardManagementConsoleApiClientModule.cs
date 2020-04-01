using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.GiftCardManagement
{
    [DependsOn(
        typeof(GiftCardManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class GiftCardManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
