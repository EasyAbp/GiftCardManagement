using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.GiftCardManagement.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.GiftCardManagement
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class GiftCardManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<GiftCardManagementDomainSharedModule>("EasyAbp.GiftCardManagement");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<GiftCardManagementResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/GiftCardManagement");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("GiftCardManagement", typeof(GiftCardManagementResource));
            });
        }
    }
}
