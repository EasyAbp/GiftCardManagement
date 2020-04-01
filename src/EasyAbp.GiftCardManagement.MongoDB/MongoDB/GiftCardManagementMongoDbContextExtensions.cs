using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.GiftCardManagement.MongoDB
{
    public static class GiftCardManagementMongoDbContextExtensions
    {
        public static void ConfigureGiftCardManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new GiftCardManagementMongoModelBuilderConfigurationOptions(
                GiftCardManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}