using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.GiftCardManagement
{
    [DependsOn(
        typeof(GiftCardManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class GiftCardManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "GiftCardManagement";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(GiftCardManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
