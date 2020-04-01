using Localization.Resources.AbpUi;
using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.GiftCardManagement
{
    [DependsOn(
        typeof(GiftCardManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class GiftCardManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(GiftCardManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<GiftCardManagementResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
